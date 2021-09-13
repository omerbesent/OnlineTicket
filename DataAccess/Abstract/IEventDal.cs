using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        //Custom Operations
        List<Event> GetListFull(Expression<Func<Event, bool>> filter = null);
        Event GetFull(Expression<Func<Event, bool>> filter = null);
    }
}
