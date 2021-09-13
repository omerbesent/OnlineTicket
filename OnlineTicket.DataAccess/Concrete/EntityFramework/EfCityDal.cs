using Microsoft.EntityFrameworkCore.Internal;
using Core.DataAccess.EntityFramework;
using OnlineTicket.DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTicket.DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfEntityRepositoryBase<City, OnlineTicketContext>, ICityDal
    {
        public List<City> CitiesWithEvents()
        {
            using (var context = new OnlineTicketContext())
            {
                //return   context.Set<City>().Join(context.Places, city=> city.CityId, place=> place. ö)
                //LeftJoin(context.Places, city => city.CityId, place => place);

                return (from city in context.Cities
                        join place in context.Places on city.CityId equals place.CityId
                        select city).Distinct().ToList();

            }
        }
    }
}
