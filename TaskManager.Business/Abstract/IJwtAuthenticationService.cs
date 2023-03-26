using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Concrete.Eframework;
using TaskManager.Entities.Concrete;
using TaskManager.Entities.Dto;

namespace TaskManager.Business.Abstract
{
    public interface IJwtAuthenticationService
    {
        //Task<Token> NewRefreshToken(RefreshToken refreshToken);
        Task<Token> GetToken(Login login);
    }
}
