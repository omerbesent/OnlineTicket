using OnlineTicket.Business.Abstract;
using OnlineTicket.DataAccess.Abstract;
using OnlineTicket.Entities.Concrete;
using System.Collections.Generic;

namespace OnlineTicket.Business.Concrete
{
    public class PlaceManager : IPlaceService
    {
        private IPlaceDal _placeDal;
        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
        }

        public void Add(Place place)
        {
            _placeDal.Add(place);
        }

        public void Update(Place place)
        {
            _placeDal.Update(place);
        }

        public void Delete(int placeId)
        {
            _placeDal.Delete(new Place { PlaceId = placeId });
        }

        public List<Place> GetAll()
        {
            return _placeDal.GetListFull();
        }

        public Place Get(int placeId)
        {
            return _placeDal.GetFull(x => x.PlaceId == placeId);
        }
    }
}
