using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEventService
    {
        IDataResult<List<Event>> GetAll();
        IDataResult<List<Event>> GetListByCategoryId(int categoryId);
        IDataResult<Event> Get(int eventId);
        IResult Add(Event evnt, Session[] sessions);
        IResult Update(Event evnt);
        IResult Delete(int evntId);
        //IDataResult<List<EventSelectedSeat>> GetSelectedSeatsByEvent(int evntId);
        //IResult SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave);
        //IResult SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete);
    }
}
