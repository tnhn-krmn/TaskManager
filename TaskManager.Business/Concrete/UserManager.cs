using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int userId)
        {
            _userDal.Delete(new User { Id = userId });
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
