using netways_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netways_task.DAL
{
    public interface ICountryRepository: IDisposable
    {
        IEnumerable<Country> GetCountries();
        Country GetCountryByID(int id);
        void InsertCountry(Country country);
        void DeleteCountry(int id);
        void UpdateCountry(Country country);
        void Save();
    }
}