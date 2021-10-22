using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CountyManager : ICountyService
    {
        private ICountyDal _countyDal;
        public CountyManager(ICountyDal countyDal)
        {
            _countyDal = countyDal;
        }
        public IResult Add(County county)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int countyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<County> Get(int countyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<County>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<County>> GetListByCityId(int cityId)
        { 
            return new SuccessDataResult<List<County>>(_countyDal.GetList(x => x.CityId == cityId), Messages.CountyListed);
        }

        public IResult Update(County county)
        {
            throw new NotImplementedException();
        }
    }
}
