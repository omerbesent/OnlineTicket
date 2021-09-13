using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        private IEventDal _eventDal;
        //private IEventSelectedSeatDal _evntSelectedSeatDal;
        //public EventManager(IEventDal eventDal, IEventSelectedSeatDal evntSelectedSeatDal)
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
            //_evntSelectedSeatDal = evntSelectedSeatDal;
        }

        public IResult Add(Event evnt)
        {
            //checklik bir durum varsa
            //var result = BusinessRules.Run(
            //    CheckIfProductCountOfCategoryCorrect(product.CategoryId),
            //    CheckIfProductNameExists(product.ProductName),
            //    CheckIfCategoryLimitExceded()
            //    );
            //if (result != null)
            //{
            //    return result;
            //}

            _eventDal.Add(evnt);
            return new SuccessResult(Messages.EventAdded);
        }

        public IResult Delete(int evntId)
        {
            //checklik bir durum varsa
            //var result = BusinessRules.Run(
            //    CheckIfProductCountOfCategoryCorrect(product.CategoryId),
            //    CheckIfProductNameExists(product.ProductName),
            //    CheckIfCategoryLimitExceded()
            //    );
            //if (result != null)
            //{
            //    return result;
            //}

            var evnt = _eventDal.Get(x => x.EventId == evntId);
            _eventDal.Delete(evnt);
            return new SuccessResult(Messages.EventDeleted);
        }

        public IDataResult<Event> Get(int eventId)
        {
            return new SuccessDataResult<Event>(_eventDal.GetFull(x => x.EventId == eventId), Messages.EventsListed);
        }

        public IDataResult<List<Event>> GetAll()
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetListFull(), Messages.EventsListed);
        }

        public IDataResult<List<Event>> GetListByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetListFull(x => x.CategoryId.Value == categoryId), Messages.EventsListed);
        }

        //public IDataResult<List<EventSelectedSeat>> GetSelectedSeatsByEvent(int evntId)
        //{
        //    return new SuccessDataResult<List<EventSelectedSeat>>(_evntSelectedSeatDal.GetList(x => x.EventId == evntId), Messages.SeatsListed); 
        //}

        //public IResult SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave)
        //{
        //    var deleteSelectedSeats = _evntSelectedSeatDal.GetList(x => x.EventId == evntSelectedsSave[0].EventId);
        //    _evntSelectedSeatDal.AddAll(evntSelectedsSave, deleteSelectedSeats.ToArray());
        //    return new SuccessResult(Messages.SelectedSeatsAdded);
        //}

        //public IResult SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete)
        //{
        //    _evntSelectedSeatDal.DeleteAll(evntSelectedsDelete);
        //    return new SuccessResult(Messages.SelectedSeatsDeleted);
        //}

        public IResult Update(Event evnt)
        {
            //checklik bir durum varsa
            //var result = BusinessRules.Run(
            //    CheckIfProductCountOfCategoryCorrect(product.CategoryId),
            //    CheckIfProductNameExists(product.ProductName),
            //    CheckIfCategoryLimitExceded()
            //    );
            //if (result != null)
            //{
            //    return result;
            //}

            _eventDal.Update(evnt);
            return new SuccessResult(Messages.EventUpdated);
        }
    }
}
