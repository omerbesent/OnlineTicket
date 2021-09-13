using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICityService
    {
        List<City> GetAll();
        City Get(int cityId);
        void Add(City city);
        void Update(City city);
        void Delete(int cityId);
        List<City> CitiesWithEvents();
    }
}
