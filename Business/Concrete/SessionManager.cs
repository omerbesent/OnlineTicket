using Business.Abstract;
using Business.Constans;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
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

        public IResult Add(Session session)
        {
            _sessionDal.Add(session);
            return new SuccessResult(Messages.SessionAdded);
        }

        public IResult AddAll(Session[] session)
        {
            _sessionDal.AddAll(session);
            return new SuccessResult(Messages.SessionAdded);
        }

        public IResult Delete(int sessionId)
        {
            _sessionDal.Delete(new Session { SessionId = sessionId });
            return new SuccessResult(Messages.SessionDeleted);
        }

        public IDataResult<Session> Get(int sessionId)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(x => x.SessionId == sessionId), Messages.SessionListed);
        }

        public IDataResult<Session> Get(int eventId, string session)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(x => x.EventId == eventId && x.EventSession == session), Messages.SessionListed);
        }

        public IDataResult<List<Session>> GetAll()
        {
            return new SuccessDataResult<List<Session>>(_sessionDal.GetList(), Messages.SessionListed);
        }

        public IDataResult<List<Session>> GetByEventId(int eventId)
        {
            return new SuccessDataResult<List<Session>>(_sessionDal.GetList(x => x.EventId == eventId), Messages.SessionListed);
        }

        public IResult Update(Session session)
        {
            _sessionDal.Update(session);
            return new SuccessResult(Messages.SessionUpdated);
        }

        [TransactionScopeAspect]
        public IResult UpdateAll(Session[] session, Session[] deleteSession)
        {
            _sessionDal.DeleteAll(deleteSession);
            _sessionDal.AddAll(session);
            return new SuccessResult(Messages.SessionUpdated);
        }
    }
}
