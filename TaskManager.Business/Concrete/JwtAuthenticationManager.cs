using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Abstract;
using TaskManager.Core.Settings;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;
using TaskManager.Entities.Dto;

namespace TaskManager.Business.Concrete
{
    public class JwtAuthenticationManager : IJwtAuthenticationService
    {
        private readonly TokenSettings _tokenSettings;
        private readonly IUserDal _userDal;

        public JwtAuthenticationManager(IOptions<TokenSettings> tokenSettings, IUserDal userDal)
        {
            _tokenSettings = tokenSettings.Value;
            _userDal = userDal;
        }

        public async Task<Token> GetToken(Login login)
        {
            User user = _userDal.GetUserWithId(login.Email);

            if (user != null)
            {
                var token = new Token
                {
                    AccessToken = CreateJwtToken(user),
                };
                return token;
            }

            return null;
        }

        private string CreateJwtToken(User user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_tokenSettings.SecretKey)
            );
            var credentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
            );
            var userCliams = new Claim[]{
            new Claim("UserName", user.UserName),
            new Claim("email", user.Email)
            };

            var jwtToken = new JwtSecurityToken(
                signingCredentials: credentials,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(10),
                issuer: _tokenSettings.Issuer,
                claims: userCliams
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
