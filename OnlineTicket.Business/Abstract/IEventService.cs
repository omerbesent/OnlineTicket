using OnlineTicket.Entities.Concrete;
using System.Collections.Generic;

namespace OnlineTicket.Business.Abstract
{
    public interface IEventService
    {
        List<Event> GetAll();
        List<Event> GetListByCategoryId(int categoryId);
        Event Get(int evntId);
        int Add(Event evnt);
        bool Update(Event evnt);
        bool Delete(int evntId);
        IList<EventSelectedSeat> GetSelectedSeatsByEvent(int evntId);
        void SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave);
        void SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete);
    }
}
