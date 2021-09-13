using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserSelectedSeatDal : IEntityRepository<UserSelectedSeat>
    {
        //Custom Operations
        void DeleteAll(UserSelectedSeat[] userSelectedSeats);
    }
}
