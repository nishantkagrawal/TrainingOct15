using System;
using System.Linq;
using System.Linq.Expressions;

namespace MVCTest.Repository
{
    /// <summary>
    /// Readonly Repository interface.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(object id);

        TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
    }
}