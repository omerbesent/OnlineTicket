using Core.DataAccess;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Abstract
{
    public interface IUserSelectedSeatDal : IEntityRepository<UserSelectedSeat>
    {
        //Custom Operations
        void DeleteAll(UserSelectedSeat[] userSelectedSeats);
    }
}
