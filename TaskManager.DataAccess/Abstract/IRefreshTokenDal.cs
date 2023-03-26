using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.DataAccess.Eframework.Abstract;
using TaskManager.Entities.Concrete;
using TaskManager.Entities.Dto;

namespace TaskManager.DataAccess.Abstract
{
    public interface IRefreshTokenDal : IEntityRepository<RefreshToken>
    {
        public bool IsRefreshToken(string token);
        public bool RefreshTokenSave(RefreshToken token);
        //public NewRefreshToken UserRefreshToken(NewRefreshToken token);
    }
}
