using Microsoft.EntityFrameworkCore;
using Core.DataAccess.EntityFramework;
using OnlineTicket.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineTicket.DataAccess.Concrete.EntityFramework
{
    public class EfEventDal : EfEntityRepositoryBase<Event, OnlineTicketContext>, IEventDal
    {
        public List<Event> GetListFull(Expression<Func<Event, bool>> filter = null)
        {
            using (var context = new OnlineTicketContext())
            {
                return filter == null
                    ? context.Set<Event>().Include(x => x.Category).Include(x => x.Place).Include(x => x.Place.City).Include(x => x.Place.County).Include(x => x.Sessions).Include(x => x.EventSelectedSeats).ToList()
                    : context.Set<Event>().Where(filter).Include(x => x.Category).Include(x => x.Place).Include(x => x.Place.City).Include(x => x.Place.County).Include(x => x.Sessions).Include(x => x.EventSelectedSeats).ToList();
            }
        }

        public Event GetFull(Expression<Func<Event, bool>> filter = null)
        {
            using (var context = new OnlineTicketContext())
            {
                return context.Set<Event>().Include(x => x.Category).Include(x => x.Place).Include(x => x.Place.City).Include(x => x.Place.County).Include(x => x.Sessions).Include(x => x.EventSelectedSeats).SingleOrDefault(filter);
            }
        }
    }
}
