using netways_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netways_task.DAL
{
    public class UnitOfWork : IDisposable
    {
        private NetwaysContext context = new NetwaysContext();
        private GenericRepository<Country> countriesRepository;
      
        public GenericRepository<Country> CourseRepository
        {
            get
            {

                if (this.countriesRepository == null)
                {
                    this.countriesRepository = new GenericRepository<Country>(context);
                }
                return countriesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}