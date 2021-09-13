using Core.DataAccess;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Abstract
{
    public interface IPlaceSeatingPlanDal : IEntityRepository<PlaceSeatingPlan>
    {
        //Custom Operations 
        void AddAll(PlaceSeatingPlan[] entitySave, PlaceSeatingPlan[] entityDelete);
        void DeleteAll(PlaceSeatingPlan[] entityDelete);
    }
}
