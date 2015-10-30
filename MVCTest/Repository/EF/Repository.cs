using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MVCTest.Repository.EF
{
    //http://codereview.stackexchange.com/questions/55127/unit-of-work-repository-nhibernate
    //http://blog.longle.net/2013/05/11/genericizing-the-unit-of-work-pattern-repository-pattern-with-entity-framework-in-mvc/

    /****Correct Use of Repository*****
    https://codefizzle.wordpress.com/2012/07/26/correct-use-of-repository-and-unit-of-work-patterns-in-asp-net-mvc/
    We used the same pattern in AgileTax/TaxSimple. Just the work UnitOfWork was not used
    */

    //public class Repository<T> : IRWRepository<T> where T : IEntity
    //{
    //    private UnitOfWork unitOfWork;

    //    public Repository(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = (UnitOfWork)unitOfWork;
    //    }

    //    protected ISession Session
    //    {
    //        get { return this.unitOfWork.Session; }
    //    }

    //    public IQueryable<T> GetAll()
    //    {
    //        return this.Session.Query<T>();
    //    }

    //    public T GetById(object id)
    //    {
    //        return this.Session.Get<T>(id);
    //    }

    //    public T FindBy(Expression<Func<T, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Add(T entity)
    //    {
    //        this.Session.Save(entity);
    //        return true;
    //    }

    //    public bool Add(IEnumerable<T> Entities)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Update(T entity)
    //    {
    //        this.Session.Update(entity);
    //        return true;
    //    }

    //    public bool Update(IEnumerable<T> Entities)
    //    {
    //        foreach (T entity in Entities)
    //        {
    //            this.Session.Update(entity);
    //        }

    //        return true;
    //    }

    //    public bool Delete(int id)
    //    {
    //        this.Session.Delete(this.Session.Load<T>(id));
    //        return true;
    //    }

    //    public bool Delete(IEnumerable<T> Entities)
    //    {
    //        foreach (T entity in Entities)
    //        {
    //            this.Session.Delete(entity);
    //        }

    //        return true;
    //    }
    //}

    /// <summary>
    /// Base repository for all Repositories
    /// </summary>
    /// <typeparam name="T">
    /// The type of repository
    /// </typeparam>
    public class Repository<T> : IRwRepository<T> where T : class, IEntity
    {
        //Inject ISession in the Repository class instead of UnitOfWork
        //because this class will be used to generate properties in UnitOfWork
        //Session is something like DbSet in EntityFramework

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbset">
        /// The dbset.
        /// </param>
        public Repository(DbSet<T> dbset)
        {
            this.Dbset = dbset;
        }

        /// <summary>
        /// Gets the dbset.
        /// </summary>
        protected DbSet<T> Dbset { get; }

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
            this.Dbset.Add(entity);
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
            var entityToDelete = this.Dbset.SingleOrDefault(p => p.Id == id);
            if (entityToDelete != null)
            {
                this.Dbset.Remove(entityToDelete);
                return true;
            }

            return false;
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
            this.Dbset.Remove(entity);
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
                this.Dbset.Remove(entity);
            }

            return true;

            //return true;
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
            return this.Dbset;
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
            throw new NotImplementedException();

            //return this.Dbset.SingleOrDefault(p => p.Id == (int)id);
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
            throw new NotImplementedException();

            //this.Session.Update(entity);
            //return true;
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
            throw new NotImplementedException();

            //foreach (T entity in Entities)
            //{
            //    this.Session.Update(entity);
            //}

            //return true;
        }
    }
}