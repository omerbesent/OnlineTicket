using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPlaceService
    {
        IDataResult<List<Place>> GetAll();
        IDataResult<Place> Get(int placeId);
        IResult Add(Place place);
        IResult Update(Place place);
        IResult Delete(int placeId);
    }
}
