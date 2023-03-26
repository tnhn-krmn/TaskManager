using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly IRefreshTokenDal _refreshTokenDal;

        public JwtAuthenticationManager(IOptions<TokenSettings> tokenSettings, IUserDal userDal, IRefreshTokenDal refreshTokenDal)
        {
            _tokenSettings = tokenSettings.Value;
            _userDal = userDal;
            _refreshTokenDal = refreshTokenDal;
        }

        public async Task<Token> GetToken(Login login)
        {
            User user = _userDal.GetUserWithId(login.Email);

            if (user != null)
            {
                var refreshToken = CreateRefreshToken();
                var token = new Token
                {
                    RefreshToken = refreshToken,
                    AccessToken = CreateJwtToken(user),

                };
                await InsertRefreshToken(user.Id, refreshToken);

                return token;
            }

            return null;
        }

        //public async Task<Token> NewRefreshToken(RefreshToken refreshToken)
        //{
        //    var uRefreshToken = _refreshTokenDal.UserRefreshToken(refreshToken);
        //    if (uRefreshToken != null)
        //    {
        //        var user = _userDal.GetUserToken(uRefreshToken);
        //        var newTokenJwt = CreateJwtToken(user);
        //        var newRefreshToken = CreateRefreshToken();

        //        uRefreshToken.Token = newTokenJwt;
        //        uRefreshToken.ExpirationDate = DateTime.Now.AddDays(10);
        //        var newRefreshTokenSave = _refreshTokenDal.RefreshTokenSave(uRefreshToken);

        //        return new Token
        //        {
        //            AccessToken = newTokenJwt,
        //            RefreshToken = newRefreshToken
        //        };
        //    }
        //    return null;
        //}

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

        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var IsToken = _refreshTokenDal.IsRefreshToken(refreshToken);

            if (IsToken)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }

        private async Task InsertRefreshToken(int userId, string refreshtoken)
        {
            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = refreshtoken,
                ExpirationDate = DateTime.Now.AddDays(10)
            };
            _refreshTokenDal.RefreshTokenSave(refreshToken);

        }
    }
}
