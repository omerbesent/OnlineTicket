using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISessionService
    {
        IDataResult<List<Session>> GetAll();
        IDataResult<List<Session>> GetByEventId(int eventId);
        IDataResult<Session> Get(int sessionId);
        IDataResult<Session> Get(int eventId, string session);
        IResult Add(Session session);
        IResult AddAll(Session[] session);
        IResult Update(Session session);
        IResult UpdateAll(Session[] session, Session[] deleteSession);
        IResult Delete(int sessionId);
    }
}
