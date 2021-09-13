using Core.DataAccess;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Abstract
{
    public interface IEventSelectedSeatDal : IEntityRepository<EventSelectedSeat>
    {
        //Custom Operations
        void AddAll(EventSelectedSeat[] entitySave, EventSelectedSeat[] entityDelete);
        void DeleteAll(EventSelectedSeat[] entityDelete);
    }
}
