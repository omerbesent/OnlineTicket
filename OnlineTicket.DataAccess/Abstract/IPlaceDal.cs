using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineTicket.DataAccess.Abstract
{
    public interface IPlaceDal : IEntityRepository<Place>
    {
        //Custom Operations
        List<Place> GetListFull(Expression<Func<Place, bool>> filter = null);
        Place GetFull(Expression<Func<Place, bool>> filter = null);
    }
}
