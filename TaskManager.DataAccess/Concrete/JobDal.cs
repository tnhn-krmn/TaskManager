using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.DataAccess.Eframework.Concrete;
using TaskManager.DataAccess.Abstract;
using TaskManager.DataAccess.Concrete.Eframework;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.Concrete
{
    public class JobDal : EfRepository<Job,Context>,IJobDal
    {
        public List<Job> GetListOneWeekTodo()
        {

            DateTime date = DateTime.Now.Date.AddDays(7);
            var job = GetDateMatch(date);
            return job;
        }

        public List<Job> GetListOneMonthTodo()
        {
            DateTime date = DateTime.Now.Date.AddDays(30);
            var job = GetDateMatch(date);
            return job;
        }

        public List<Job> GetListOneDayTodo()
        {
            DateTime date = DateTime.Now.Date.AddHours(24);
            var job = GetDateMatch(date);
            return job;
        }

        private List<Job> GetDateMatch(DateTime date)
        {
            using (var context = new Context())
            {
                var job = context.Jobs.Where(x => x.Date >= DateTime.Now.Date && x.Date < date.Date).ToList();
                return job;
            }
        }
    }
}
