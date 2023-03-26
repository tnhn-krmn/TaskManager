using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities.Dto;

namespace TaskManager.Business.Abstract
{
    public interface IJwtAuthenticationService
    {
        Task<Token> GetToken(Login login);
    }
}
