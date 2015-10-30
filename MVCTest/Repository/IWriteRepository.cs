using System.Collections.Generic;

namespace MVCTest.Repository
{
    /// <summary>
    /// The WriteRepository interface.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IEntity"/> type
    /// </typeparam>
    public interface IWriteRepository<in TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Add(TEntity entity);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Update(TEntity entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Delete(int id);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Delete(IEnumerable<TEntity> entities);
    }
}