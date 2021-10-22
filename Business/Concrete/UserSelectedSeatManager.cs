using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserSelectedSeatManager : IUserSelectedSeatService
    {
        IUserSelectedSeatDal _userSelectedSeatDal;
        public UserSelectedSeatManager(IUserSelectedSeatDal userSelectedSeatDal)
        {
            _userSelectedSeatDal = userSelectedSeatDal;
        }

        public IResult Add(UserSelectedSeat userSelectedSeat)
        {
            _userSelectedSeatDal.Add(userSelectedSeat);
            return new SuccessResult(Messages.UserSelectedSeatAdded);
        }

        public IResult CheckAndDeleteSession(int eventId, string session)
        {
            var deleted = _userSelectedSeatDal.GetList(x => x.EventId == eventId && x.Session == session);
            _userSelectedSeatDal.DeleteAll(deleted.ToArray());
            return new SuccessResult(Messages.UserSelectedSeatDeleted);
        }

        public IDataResult<bool> CheckSeat(int eventId, string session, string seat)
        {
            var check = false;
            _userSelectedSeatDal.Get(x => x.EventId == eventId && x.Session == session && x.Seat == seat);
            if (_userSelectedSeatDal != null)
                check = true;
            return new SuccessDataResult<bool>(check, Messages.UserSelectedSeatListed);
        }

        public IResult Delete(int userSelectedSeatId)
        {
            _userSelectedSeatDal.Delete(new UserSelectedSeat { Id = userSelectedSeatId });
            return new SuccessResult(Messages.UserSelectedSeatDeleted);
        }

        public IDataResult<UserSelectedSeat> Get(int userSelectedSeatId)
        {
            return new SuccessDataResult<UserSelectedSeat>(_userSelectedSeatDal.Get(x => x.Id == userSelectedSeatId), Messages.UserSelectedSeatListed);
        }

        public IDataResult<List<UserSelectedSeat>> GetAll()
        {
            return new SuccessDataResult<List<UserSelectedSeat>>(_userSelectedSeatDal.GetList(), Messages.UserSelectedSeatListed);
        }

        public IDataResult<UserSelectedSeat> GetBySeat(string sessionId, int eventId, string session, string seat)
        {
            return new SuccessDataResult<UserSelectedSeat>(_userSelectedSeatDal.Get(x => x.SessionId == sessionId && x.EventId == eventId && x.Session == session && x.Seat == seat), Messages.UserSelectedSeatListed);
        }

        public IDataResult<List<UserSelectedSeat>> GetBySessionId(string sessionId, int eventId, string session)
        {
            return new SuccessDataResult<List<UserSelectedSeat>>(_userSelectedSeatDal.GetList(x => x.SessionId == sessionId && x.EventId == eventId && x.Session == session), Messages.UserSelectedSeatListed);
        }

        public IResult Update(UserSelectedSeat userSelectedSeat)
        {
            _userSelectedSeatDal.Update(userSelectedSeat);
            return new SuccessResult(Messages.UserSelectedSeatUpdated);
        }

        public IResult UpdateDeletionTime(string sessionId, int? userId, int eventId, string session)
        {
            var userSelectedSeats = new List<UserSelectedSeat>();
            if (userId.HasValue)
                userSelectedSeats = _userSelectedSeatDal.GetList(x => x.UserId.Value == userId.Value);
            else
                userSelectedSeats = _userSelectedSeatDal.GetList(x => x.SessionId==sessionId);
            foreach (var item in userSelectedSeats)
            {
                item.ProcessDate = DateTime.Now;
                Update(item);
            }
            return new SuccessResult(Messages.UserSelectedSeatUpdated);
        }
    }
}
