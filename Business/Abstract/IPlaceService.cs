using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPlaceService
    {
        List<Place> GetAll();
        Place Get(int placeId);
        void Add(Place place);
        void Update(Place place);
        void Delete(int placeId);
    }
}
