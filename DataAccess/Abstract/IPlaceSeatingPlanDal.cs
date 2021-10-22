using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPlaceSeatingPlanDal : IEntityRepository<PlaceSeatingPlan>
    {
        //Custom Operations 
        void AddAll(PlaceSeatingPlan[] entitySave);
        void DeleteAll(PlaceSeatingPlan[] entityDelete);
    }
}
