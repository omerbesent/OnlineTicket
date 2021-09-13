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
    public class EfPlaceDal : EfEntityRepositoryBase<Place, OnlineTicketContext>, IPlaceDal
    {
        public List<Place> GetListFull(Expression<Func<Place, bool>> filter = null)
        {
            using (var context = new OnlineTicketContext())
            {
                return filter == null
                    ? context.Set<Place>().Include(x => x.City).Include(x => x.County).ToList()
                    : context.Set<Place>().Where(filter).Include(x => x.City).ToList();
            }
        }

        public Place GetFull(Expression<Func<Place, bool>> filter = null)
        {
            using (var context = new OnlineTicketContext())
            {
                return context.Set<Place>().Include(x => x.City).Include(x => x.County).SingleOrDefault(filter);
            }
        }
    }
}
