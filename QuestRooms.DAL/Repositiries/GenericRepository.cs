using QuestRooms.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Repositiries
{
    public class GenericRepository<TEntity> :
        IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        public GenericRepository(DbContext _db)
        {
            context = _db;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsEnumerable();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).AsEnumerable();
        }
        public void Create(TEntity item)
        {
            context.Set<TEntity>().Add(item);
            context.SaveChanges();
        }
        public void Delete(TEntity Id)
        {
            context.Set<TEntity>().Remove(Id);
            context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return context.Set<TEntity>().Find(predicate);
        }

    }
}
