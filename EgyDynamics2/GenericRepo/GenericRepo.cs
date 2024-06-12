using EgyDynamics2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EgyDynamics2.GenericRepo
{
    public class GenericRepo<TEntity> where TEntity : class
    {
        EgyDynamicsContext dbcontext;
        public GenericRepo(EgyDynamicsContext _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }
        public List<TEntity> SelectAll()
        {
            return dbcontext.Set<TEntity>().ToList();
        }
        public List<TEntity> SelectAllInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbcontext.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }

        //for pagination
        public List<TEntity> SelectAllIncludePagination(int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbcontext.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Apply pagination
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return query.ToList();
        }
        public List<TEntity> GetEntitiesByForeignKey<TEntity>(int foreignKey, string foreignKeyPropertyName)
    where TEntity : class
        {

            var entities = dbcontext.Set<TEntity>().Where(entity =>
                EF.Property<int>(entity, foreignKeyPropertyName) == foreignKey).ToList();

            return entities;
        }

        public void DeleteEntities(List<TEntity> entities)
        {
            dbcontext.Set<TEntity>().RemoveRange(entities);
        }
        public int Count()
        {
            return dbcontext.Set<TEntity>().Count();
        }
        public TEntity selectbyid(int keyValues)
        {
            return dbcontext.Set<TEntity>().Find(keyValues);
        }
        public TEntity SelectByIDInclude(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbcontext.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return dbcontext.Set<TEntity>().Find(id);
        }
        public void Add(TEntity entity)
        {
            dbcontext.Set<TEntity>().Add(entity);
        }
        public void delete(int id)
        {
            TEntity obj = dbcontext.Set<TEntity>().Find(id);
            dbcontext.Set<TEntity>().Remove(obj);
        }
        public void update(TEntity entity)
        {
           dbcontext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbcontext.Set<TEntity>().FirstOrDefault(predicate);
        }

    }
}


