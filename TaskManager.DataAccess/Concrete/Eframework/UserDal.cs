using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.DataAccess.Eframework.Concrete;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Concrete.Eframework
{
    public class UserDal : EfRepository<User,Context>, IUserDal
    {
    }
}
