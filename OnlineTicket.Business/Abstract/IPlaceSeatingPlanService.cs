using OnlineTicket.Entities.Concrete;
using System.Collections.Generic;

namespace OnlineTicket.Business.Abstract
{
    public interface IPlaceSeatingPlanService
    {
        List<PlaceSeatingPlan> GetAll();
        List<PlaceSeatingPlan> GetByPlace(int placeId);
        void Add(PlaceSeatingPlan placeSeatingPlan);
        void AddAll(PlaceSeatingPlan[] placeSeatingPlansSave, PlaceSeatingPlan[] placeSeatingPlansDelete);
        void Update(PlaceSeatingPlan placeSeatingPlan);
        void Delete(int placeSeatingPlanId);
        void DeleteAll(PlaceSeatingPlan[] placeSeatingPlansDelete);
        PlaceSeatingPlan Get(int placeId);
    }
}
