using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities.Abstract;

namespace TaskManager.Core.DataAccess.Eframework.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
