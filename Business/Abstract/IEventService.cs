using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEventService
    {
        IDataResult<List<Event>> GetAll();
        IDataResult<List<Event>> GetListByCategoryId(int categoryId);
        IDataResult<Event> Get(int eventId);
        IResult Add(EventDto eventDto);
        IResult Update(EventDto eventDto);
        IResult Delete(int evntId); 
    }
}
