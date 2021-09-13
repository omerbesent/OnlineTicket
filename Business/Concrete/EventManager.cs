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
        //private ICategoryDal _categoryDal;
        //private IEventSelectedSeatDal _evntSelectedSeatDal;
        //public EventManager(IEventDal eventDal, IEventSelectedSeatDal evntSelectedSeatDal)
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
            //_categoryDal = categoryDal;
            //_evntSelectedSeatDal = evntSelectedSeatDal;
        }

        public int Add(Event evnt)
        {
            try
            {
                return _eventDal.Add(evnt);
                //return true;
            }
            catch (Exception exc)
            {
                return -1;
            }
        }

        public bool Delete(int evntId)
        {
            try
            {
                _eventDal.Delete(new Event { EventId = evntId });
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
        public Event Get(int evntId)
        {
            return _eventDal.GetFull(x => x.EventId == evntId);
        }

        IDataResult<List<Event>> GetAll()
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetListFull(), Messages.EventsListed);
        }

        public List<Event> GetListByCategoryId(int categoryId)
        {
            //var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            //_categoryDal.GetList(x => x.MainCategoryId == categoryId).Select(x => x.CategoryId).ToArray();
            return _eventDal.GetListFull(x => x.CategoryId.Value == categoryId);
        }

        public IList<EventSelectedSeat> GetSelectedSeatsByEvent(int evntId)
        {
            throw new NotImplementedException();
        }

        public void SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave)
        {
            throw new NotImplementedException();
        }

        public void SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete)
        {
            throw new NotImplementedException();
        }

        //public IList<EventSelectedSeat> GetSelectedSeatsByEvent(int evntId)
        //{
        //    var evntSelectedSeats = _evntSelectedSeatDal.GetList(x => x.EventId == evntId);
        //    return evntSelectedSeats;
        //}

        //public void SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave)
        //{
        //    var deleteSelectedSeats = _evntSelectedSeatDal.GetList(x => x.EventId == evntSelectedsSave[0].EventId);
        //    _evntSelectedSeatDal.AddAll(evntSelectedsSave, deleteSelectedSeats.ToArray());
        //}

        //public void SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete)
        //{
        //    _evntSelectedSeatDal.DeleteAll(evntSelectedsDelete);
        //}

        public bool Update(Event evnt)
        {
            try
            {
                _eventDal.Update(evnt);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }


    }
}
