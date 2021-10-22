using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPlaceSeatingPlanService
    {
        IDataResult<List<PlaceSeatingPlan>> GetAll();
        IDataResult<List<PlaceSeatingPlan>> GetByPlace(int placeId);
        IResult Add(PlaceSeatingPlan placeSeatingPlan);
        IResult AddAll(PlaceSeatingPlan[] placeSeatingPlansSave, PlaceSeatingPlan[] placeSeatingPlansDelete);
        IResult Update(PlaceSeatingPlan placeSeatingPlan);
        IResult Delete(int placeSeatingPlanId);
        IResult DeleteAll(PlaceSeatingPlan[] placeSeatingPlansDelete);
        IDataResult<PlaceSeatingPlan> Get(int placeSeatingPlanId);
    }
}
