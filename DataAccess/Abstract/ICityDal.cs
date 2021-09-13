using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
        //Custom Operations
        List<City> CitiesWithEvents();
    }
}
