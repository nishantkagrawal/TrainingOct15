using System;
using System.Linq;
using System.Linq.Expressions;

namespace MVCTest.Repository
{
    /// <summary>
    /// Readonly Repository interface.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IEntity"/> type
    /// </typeparam>
    public interface IReadRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity GetById(object id);

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// The filter by.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
    }
}