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
    public interface IUserDal : IEntityRepository<User>
    {
        public User GetUserWithId(string email);
        public User GetUserToken(int userId);
    }
}
