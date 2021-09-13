using Core.DataAccess.EntityFramework;
using OnlineTicket.DataAccess.Abstract;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Concrete.EntityFramework
{
    public class EfSessionDal : EfEntityRepositoryBase<Session, OnlineTicketContext>, ISessionDal
    {
        public bool AddAll(Session[] entitySave)
        {
            using (var context = new OnlineTicketContext())
            {
                context.AddRange(entitySave);
                context.SaveChanges();

                return true;
            }
        }

        public bool UpdateAll(Session[] entitySave, Session[] entityDelete)
        {
            using (var context = new OnlineTicketContext())
            {
                context.RemoveRange(entityDelete);
                context.AddRange(entitySave);
                context.SaveChanges();

                return true;
            }
        }
    }
}
