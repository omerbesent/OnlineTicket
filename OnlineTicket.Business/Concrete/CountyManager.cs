using OnlineTicket.Business.Abstract;
using OnlineTicket.DataAccess.Abstract;
using OnlineTicket.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace OnlineTicket.Business.Concrete
{
    public class CountyManager : ICountyService
    {
        private ICountyDal _countyDal;
        public CountyManager(ICountyDal countyDal)
        {
            _countyDal = countyDal;
        }
        public void Add(County county)
        {
            throw new NotImplementedException();
        }

        public void Delete(int countyId)
        {
            throw new NotImplementedException();
        }

        public County Get(int countyId)
        {
            throw new NotImplementedException();
        }

        public List<County> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<County> GetListByCityId(int cityId)
        {
            return _countyDal.GetList(x => x.CityId == cityId);
        }

        public void Update(County county)
        {
            throw new NotImplementedException();
        }
    }
}
