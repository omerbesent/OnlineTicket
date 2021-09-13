using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPlaceSeatingPlanDal : EfEntityRepositoryBase<PlaceSeatingPlan, OnlineTicketContext>, IPlaceSeatingPlanDal
    {
        public void AddAll(PlaceSeatingPlan[] entitySave, PlaceSeatingPlan[] entityDelete)
        {
            using (var context = new OnlineTicketContext())
            {
                context.RemoveRange(entityDelete);
                foreach (var item in entitySave)
                {
                    context.Add(item);
                }

                context.SaveChanges();
            }
        }

        public void DeleteAll(PlaceSeatingPlan[] entityDelete)
        {
            using (var context = new OnlineTicketContext())
            {
                context.RemoveRange(entityDelete);
                context.SaveChanges();
            }
        }
    }
}
