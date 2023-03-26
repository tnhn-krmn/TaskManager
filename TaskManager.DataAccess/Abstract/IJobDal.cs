using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.DataAccess.Eframework.Abstract;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Abstract
{
    public interface IJobDal : IEntityRepository<Job>
    {
        public List<Job> GetListOneWeekTodo();
        public List<Job> GetListOneMonthTodo();
        public List<Job> GetListOneDayTodo();
    }
}
