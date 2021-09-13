using Core.DataAccess.EntityFramework;
using OnlineTicket.DataAccess.Abstract;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Concrete.EntityFramework
{
    public class EfEventSelectedSeatDal : EfEntityRepositoryBase<EventSelectedSeat, OnlineTicketContext>, IEventSelectedSeatDal
    {
        public void AddAll(EventSelectedSeat[] entitySave, EventSelectedSeat[] entityDelete)
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

        public void DeleteAll(EventSelectedSeat[] entityDelete)
        {
            using (var context = new OnlineTicketContext())
            {
                context.RemoveRange(entityDelete);
                context.SaveChanges();
            }
        }
    }
}
