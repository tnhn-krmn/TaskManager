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
    public class JobManager : IJobService
    {
        private readonly IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public List<Job> OneDayTodo()
        {
            return _jobDal.GetListOneDayTodo();
        }

        public List<Job> OneWeekTodo()
        {
            return _jobDal.GetListOneWeekTodo();
        }

        public List<Job> ThirtyDaysTodo()
        {
            return _jobDal.GetListOneMonthTodo();
        }
    }
}
