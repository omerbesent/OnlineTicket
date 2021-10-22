using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        private IEventDal _eventDal;
        private ISessionDal _sessionDal;
        private readonly IHostingEnvironment _hostingEnvironment;
        //private IEventSelectedSeatDal _evntSelectedSeatDal;
        //public EventManager(IEventDal eventDal, IEventSelectedSeatDal evntSelectedSeatDal)
        public EventManager(IEventDal eventDal, ISessionDal sessionDal, IHostingEnvironment hostingEnvironment)
        {
            _eventDal = eventDal;
            _sessionDal = sessionDal;
            _hostingEnvironment = hostingEnvironment;
            //_evntSelectedSeatDal = evntSelectedSeatDal;
        }

        [ValidationAspect(typeof(EventValidator))]
        [CacheRemoveAspect("IEventService.Get")]
        [TransactionScopeAspect]
        public IResult Add(EventDto eventDto)
        {
            var result = BusinessRules.Run(CheckIfEventImage(eventDto.CoverPhoto));
            if (result != null)
            {
                return result;
            }

            var coverPhoto = eventDto.CoverPhoto;
            var fileNameCoverPhoto = string.Format("Event_{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmss_" + new Random().Next(100, 999)));
            var filePathCoverPhoto = string.Format(@"{0}\assets\EventImage\{1}", _hostingEnvironment.ContentRootPath, fileNameCoverPhoto);
            using (var stream = System.IO.File.Create(filePathCoverPhoto))
            {
                coverPhoto.CopyTo(stream);
            }

            var evnt = new Event()
            {
                CategoryId = eventDto.CategoryId,
                PlaceId = eventDto.PlaceId,
                Title = eventDto.Title,
                EventDetails = eventDto.EventDetails,
                Price = eventDto.Price,
                OldPrice = eventDto.OldPrice,
                Date = eventDto.Date,
                Active = eventDto.Active,
                CoverPhoto = fileNameCoverPhoto,
                CreateDate = DateTime.Now,
                CreatedBy = 1
            };

            var id = _eventDal.Add(evnt);
            if (eventDto.Sessions != null)
            {
                for (int i = 0; i < eventDto.Sessions.Length; i++)
                {
                    eventDto.Sessions[i].EventId = id;
                }
                _sessionDal.AddAll(eventDto.Sessions);
            }

            return new SuccessResult(Messages.EventAdded);
        }

        [ValidationAspect(typeof(EventValidator))]
        [CacheRemoveAspect("IEventService.Get")]
        [TransactionScopeAspect]
        public IResult Update(EventDto eventDto)
        {
            var evnt = _eventDal.Get(x => x.EventId == eventDto.EventId);
            if (evnt == null)
                return new ErrorResult(Messages.RecordNotFoundError);

            string fileNameCoverPhoto = "";
            if (eventDto.CoverPhoto != null)
            {
                var result = BusinessRules.Run(CheckIfEventImage(eventDto.CoverPhoto));
                if (result != null)
                {
                    return result;
                }

                var coverPhoto = eventDto.CoverPhoto;
                fileNameCoverPhoto = string.Format("Event_{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmss_" + new Random().Next(100, 999)));
                var filePathCoverPhoto = string.Format(@"{0}\assets\EventImage\{1}", _hostingEnvironment.ContentRootPath, fileNameCoverPhoto);
                using (var stream = System.IO.File.Create(filePathCoverPhoto))
                {
                    coverPhoto.CopyTo(stream);
                }
            }
            else
                fileNameCoverPhoto = evnt.CoverPhoto;

            evnt.CategoryId = eventDto.CategoryId;
            evnt.PlaceId = eventDto.PlaceId;
            evnt.Title = eventDto.Title;
            evnt.EventDetails = eventDto.EventDetails;
            evnt.Price = eventDto.Price;
            evnt.OldPrice = eventDto.OldPrice;
            evnt.Date = eventDto.Date;
            evnt.Active = eventDto.Active;
            evnt.CoverPhoto = fileNameCoverPhoto;
            evnt.UpdateDate = DateTime.Now;
            evnt.UpdatedBy = 1;

            _eventDal.Update(evnt);
            if (eventDto.Sessions != null)
            {
                for (int i = 0; i < eventDto.Sessions.Length; i++)
                {
                    eventDto.Sessions[i].EventId = evnt.EventId;
                }
                var deletedSessions = _sessionDal.GetList(x => x.EventId == evnt.EventId);
                _sessionDal.DeleteAll(deletedSessions.ToArray());
                _sessionDal.AddAll(eventDto.Sessions);
            }
            return new SuccessResult(Messages.EventUpdated);
        }

        [CacheRemoveAspect("IEventService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(int evntId)
        {
            var sessions = _sessionDal.GetList(x => x.EventId == evntId);
            var evnt = _eventDal.Get(x => x.EventId == evntId);
            _sessionDal.DeleteAll(sessions.ToArray());
            _eventDal.Delete(evnt);

            return new SuccessResult(Messages.EventDeleted);
        }

        public IDataResult<Event> Get(int eventId)
        {
            return new SuccessDataResult<Event>(_eventDal.GetFull(x => x.EventId == eventId), Messages.EventsListed);
        }

        [CacheAspect] //key,value
        public IDataResult<List<Event>> GetAll()
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetListFull(), Messages.EventsListed);
        }

        public IDataResult<List<Event>> GetListByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetListFull(x => x.CategoryId.Value == categoryId), Messages.EventsListed);
        }



        //Check
        private IResult CheckIfEventImage(IFormFile file)
        {
            if (file == null)
                return new ErrorResult(Messages.WebImageSelectedError);

            if (file.ContentType.Substring(0, 6) != "image/")
                return new ErrorResult(Messages.NotImageError);

            using (var image = Image.FromStream(file.OpenReadStream()))
            {
                if (image.Width != 850 && image.Height != 500)
                    return new ErrorResult(Messages.EventImageSizeError);
            }
            return new SuccessResult();
        }

    }
}
