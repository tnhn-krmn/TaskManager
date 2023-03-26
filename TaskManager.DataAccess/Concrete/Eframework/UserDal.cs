using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.DataAccess.Eframework.Concrete;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaskManager.DataAccess.Concrete.Eframework
{
    public class UserDal : EfRepository<User,Context>, IUserDal
    {
        public User GetUserWithId(string email)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(x => x.Email == email);
            }
        }
    }
}
