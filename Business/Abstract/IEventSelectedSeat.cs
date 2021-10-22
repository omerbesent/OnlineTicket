using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
   public interface IEventSelectedSeat
    {
        IDataResult<List<EventSelectedSeat>> GetSelectedSeatsByEvent(int evntId);
        IResult SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave);
        IResult SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete);
    }
}
