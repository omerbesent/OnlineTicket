using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISessionService
    {
        List<Session> GetAll();
        List<Session> GetByEventId(int eventId);
        Session Get(int sessionId);
        Session Get(int eventId, string session);
        void Add(Session session);
        void AddAll(Session[] session);
        void Update(Session session);
        void UpdateAll(Session[] session, Session[] deleteSession);
        void Delete(int sessionId);
    }
}
