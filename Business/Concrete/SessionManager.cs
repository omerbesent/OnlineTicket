using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        private ISessionDal _sessionDal;
        public SessionManager(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }

        public void Add(Session session)
        {
            _sessionDal.Add(session);
        }

        public void AddAll(Session[] session)
        {
            _sessionDal.AddAll(session);
        }

        public void Delete(int sessionId)
        {
            _sessionDal.Delete(new Session { SessionId = sessionId });
        }

        public Session Get(int sessionId)
        {
            return _sessionDal.Get(x => x.SessionId == sessionId);
        }

        public Session Get(int eventId, string session)
        {
            return _sessionDal.Get(x => x.EventId == eventId && x.EventSession == session);
        }

        public List<Session> GetAll()
        {
            return _sessionDal.GetList();
        }

        public List<Session> GetByEventId(int eventId)
        {
            return _sessionDal.GetList(x => x.EventId == eventId);
        }

        public void Update(Session session)
        {
            _sessionDal.Update(session);
        }

        public void UpdateAll(Session[] session, Session[] deleteSession)
        {
            _sessionDal.UpdateAll(session, deleteSession);
        }
    }
}
