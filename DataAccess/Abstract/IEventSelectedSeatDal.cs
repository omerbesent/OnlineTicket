using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IEventSelectedSeatDal : IEntityRepository<EventSelectedSeat>
    {
        //Custom Operations
        void AddAll(EventSelectedSeat[] entitySave);
        void DeleteAll(EventSelectedSeat[] entityDelete);
    }
}
