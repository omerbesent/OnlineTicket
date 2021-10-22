using Business.Abstract;
using Business.Constans;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EventSelectedSeatManager : IEventSelectedSeat
    {
        private IEventSelectedSeatDal _evntSelectedSeatDal;
        public EventSelectedSeatManager(IEventSelectedSeatDal evntSelectedSeatDal)
        {
            _evntSelectedSeatDal = evntSelectedSeatDal;
        }
        public IDataResult<List<EventSelectedSeat>> GetSelectedSeatsByEvent(int evntId)
        {
            return new SuccessDataResult<List<EventSelectedSeat>>(_evntSelectedSeatDal.GetList(x => x.EventId == evntId), Messages.SelectedSeatsListed);
        }

        [TransactionScopeAspect]
        public IResult SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave)
        {
            var deleteSelectedSeats = _evntSelectedSeatDal.GetList(x => x.EventId == evntSelectedsSave[0].EventId);
            _evntSelectedSeatDal.DeleteAll(deleteSelectedSeats.ToArray());
            _evntSelectedSeatDal.AddAll(evntSelectedsSave);
            return new SuccessResult(Messages.SelectedSeatsAdded);
        }

        public IResult SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete)
        {
            _evntSelectedSeatDal.DeleteAll(evntSelectedsDelete);
            return new SuccessResult(Messages.SelectedSeatsDeleted);
        }
    }
}
