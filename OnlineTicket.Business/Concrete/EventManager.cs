using OnlineTicket.Business.Abstract;
using OnlineTicket.DataAccess.Abstract;
using OnlineTicket.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace OnlineTicket.Business.Concrete
{
    public class EventManager : IEventService
    {
        private IEventDal _eventDal;
        private ICategoryDal _categoryDal;
        private IEventSelectedSeatDal _evntSelectedSeatDal;
        public EventManager(IEventDal eventDal, ICategoryDal categoryDal, IEventSelectedSeatDal evntSelectedSeatDal)
        {
            _eventDal = eventDal;
            _categoryDal = categoryDal;
            _evntSelectedSeatDal = evntSelectedSeatDal;
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

        public List<Event> GetAll()
        {
            return _eventDal.GetListFull();
        }

        public List<Event> GetListByCategoryId(int categoryId)
        {
            //var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            //_categoryDal.GetList(x => x.MainCategoryId == categoryId).Select(x => x.CategoryId).ToArray();
            return _eventDal.GetListFull(x => x.CategoryId.Value == categoryId);
        }

        public IList<EventSelectedSeat> GetSelectedSeatsByEvent(int evntId)
        {
            var evntSelectedSeats = _evntSelectedSeatDal.GetList(x => x.EventId == evntId);
            return evntSelectedSeats;
        }

        public void SelectedSeatsAddAll(EventSelectedSeat[] evntSelectedsSave)
        {
            var deleteSelectedSeats = _evntSelectedSeatDal.GetList(x => x.EventId == evntSelectedsSave[0].EventId);
            _evntSelectedSeatDal.AddAll(evntSelectedsSave, deleteSelectedSeats.ToArray());
        }

        public void SelectedSeatsDeleteAll(EventSelectedSeat[] evntSelectedsDelete)
        {
            _evntSelectedSeatDal.DeleteAll(evntSelectedsDelete);
        }

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
