
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

    //    public bool Add(IEnumerable<T> entities)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Update(T entity)
    //    {
    //        this.Session.Update(entity);
    //        return true;
    //    }

    //    public bool Update(IEnumerable<T> entities)
    //    {
    //        foreach (T entity in entities)
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

    //    public bool Delete(IEnumerable<T> entities)
    //    {
    //        foreach (T entity in entities)
    //        {
    //            this.Session.Delete(entity);
    //        }

    //        return true;
    //    }
    //}


    public class Repository<T> : IRWRepository<T> where T : class, IEntity
    {
        //Inject ISession in the Repository class instead of UnitOfWork
        //because this class will be used to generate properties in UnitOfWork
        //Session is something like DbSet in EntityFramework

        public Repository(DbSet<T> dbset)
        {
            this.Dbset = dbset;
        }

        protected DbSet<T> Dbset { get; }

        public IQueryable<T> GetAll()
        {
            return this.Dbset;
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
            //return this.Dbset.SingleOrDefault(p => p.Id == (int)id);
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();

        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Add(T entity)
        {
            this.Dbset.Add(entity);
            return true;
        }

        public bool Add(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
                        
            throw new NotImplementedException();
            //this.Session.Update(entity);
            //return true;
        }

        public bool Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();

            //foreach (T entity in entities)
            //{
            //    this.Session.Update(entity);
            //}

            //return true;
        }

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

        public bool Delete(T entity)
        {

            this.Dbset.Remove(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {            
            foreach (T entity in entities)
            {
                this.Dbset.Remove(entity);
            }
            return true;

            //return true;
        }
    }
}