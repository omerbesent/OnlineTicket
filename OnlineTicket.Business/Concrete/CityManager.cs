using OnlineTicket.Business.Abstract;
using OnlineTicket.DataAccess.Abstract;
using OnlineTicket.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace OnlineTicket.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void Add(City city)
        {
            throw new NotImplementedException();
        }

        public List<City> CitiesWithEvents()
        {
            return _cityDal.CitiesWithEvents();
        }

        public void Delete(int cityId)
        {
            throw new NotImplementedException();
        }

        public City Get(int cityId)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            return _cityDal.GetList();
        }

        public void Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}
