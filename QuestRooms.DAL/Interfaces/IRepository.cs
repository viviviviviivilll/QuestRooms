using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity :
        class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity item);
        void Delete(TEntity Id);
        void Update(TEntity item);
        TEntity Find(Func<TEntity, bool> predicate);
    }
}
