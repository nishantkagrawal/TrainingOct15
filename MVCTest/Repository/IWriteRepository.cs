using System.Collections.Generic;


namespace MVCTest.Repository
{
    public interface IWriteRepository<TEntity> where TEntity : IEntity
    {
        bool Add(TEntity entity);

        bool Add(IEnumerable<TEntity> entities);

        bool Update(TEntity entity);

        bool Update(IEnumerable<TEntity> entities);

        bool Delete(int id);

        bool Delete(TEntity entity);

        bool Delete(IEnumerable<TEntity> entities);
    }
}