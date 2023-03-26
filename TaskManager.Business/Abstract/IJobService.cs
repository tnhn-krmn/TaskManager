using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities.Concrete;

namespace TaskManager.Business.Abstract
{
    public interface IJobService
    {
        List<Job> OneDayTodo();
        List<Job> ThirtyDaysTodo();
        List<Job> OneWeekTodo();
    }
}
