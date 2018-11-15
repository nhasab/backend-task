using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using netways_task.Models;

namespace netways_task.DAL
{
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private NetwaysContext context;

        public CountryRepository(NetwaysContext context)
        {
            this.context = context;
        }
        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public Country GetCountryByID(int id)
        {
            return context.Countries.Find(id);
        }

        public void InsertCountry(Country country)
        {
            context.Countries.Add(country);
        }

        public void UpdateCountry(Country country)
        {
            context.Entry(country).State = EntityState.Modified;
        }

        public void DeleteCountry(int id)
        {
            Country country = context.Countries.Find(id);
            context.Countries.Remove(country);
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