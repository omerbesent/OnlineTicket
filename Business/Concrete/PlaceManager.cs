using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PlaceManager : IPlaceService
    {
        private IPlaceDal _placeDal;
        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
        }

        public IResult Add(Place place)
        {
            _placeDal.Add(place);
            return new SuccessResult(Messages.PlaceAdded);
        }

        public IResult Update(Place place)
        {
            _placeDal.Update(place);
            return new SuccessResult(Messages.PlaceUpdated);
        }

        public IResult Delete(int placeId)
        {
            var deleted = _placeDal.Get(x => x.PlaceId == placeId);
            _placeDal.Delete(deleted);
            return new SuccessResult(Messages.PlaceDeleted);
        }

        public IDataResult<Place> Get(int placeId)
        {
            return new SuccessDataResult<Place>(_placeDal.GetFull(x => x.PlaceId == placeId), Messages.PlacesListed);
        }

        public IDataResult<List<Place>> GetAll()
        {
            return new SuccessDataResult<List<Place>>(_placeDal.GetListFull(), Messages.PlacesListed);
        }

    }
}
