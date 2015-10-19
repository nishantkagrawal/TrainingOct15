using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCTest.Repository.nHibernate
{
    public class Repository<T> : IRWRepository<T> where T : class, IEntity
    {        
        public Repository(ISession session)
        {
            this.Session = session;
        }

        protected ISession Session { get; }

        public IQueryable<T> GetAll()
        {
            return this.Session.Query<T>();
        }

        public T GetById(object id)
        {
            return this.Session.Get<T>(id);
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
            this.Session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            this.Session.Update(entity);
            return true;
        }

        public bool Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Session.Update(entity);
            }

            return true;
        }

        public bool Delete(int id)
        {
            this.Session.Delete(this.Session.Load<T>(id));
            return true;
        }

        public bool Delete(T entity)
        {
            this.Session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Session.Delete(entity);
            }

            return true;
        }
    }
}