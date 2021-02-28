using System.Collections.Generic;

namespace World_MVC
{
    public interface IDAL
    {
        IList<City> GetCities();
        IList<Country> GetCountries();
        IList<Language> GetLanguages();
    }
}