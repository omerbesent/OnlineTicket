using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserSelectedSeatDal : EfEntityRepositoryBase<UserSelectedSeat, OnlineTicketContext>, IUserSelectedSeatDal
    {
        public void DeleteAll(UserSelectedSeat[] userSelectedSeats)
        {
            using (var context = new OnlineTicketContext())
            {
                context.RemoveRange(userSelectedSeats);
                context.SaveChanges();
            }
        }
    }
}

