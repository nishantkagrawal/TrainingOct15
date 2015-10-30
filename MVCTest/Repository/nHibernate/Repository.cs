using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace MVCTest.Repository.NHibernate
{
    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="T">Type of the Entity</typeparam>
    public class Repository<T> : IRwRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        public Repository(ISession session)
        {
            this.Session = session;
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        protected ISession Session { get; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Add(T entity)
        {
            this.Session.Save(entity);
            return true;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entities">
        /// The Entities.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Add(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Delete(int id)
        {
            this.Session.Delete(this.Session.Load<T>(id));
            return true;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Delete(T entity)
        {
            this.Session.Delete(entity);
            return true;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">
        /// The Entities.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Session.Delete(entity);
            }

            return true;
        }

        /// <summary>
        /// The filter by.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T FindBy(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<T> GetAll()
        {
            return this.Session.Query<T>();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetById(object id)
        {
            return this.Session.Get<T>(id);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Update(T entity)
        {
            this.Session.Update(entity);
            return true;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entities">
        /// The Entities.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Session.Update(entity);
            }

            return true;
        }
    }
}