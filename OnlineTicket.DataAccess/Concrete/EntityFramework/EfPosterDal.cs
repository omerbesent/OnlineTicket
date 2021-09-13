using Core.DataAccess.EntityFramework;
using OnlineTicket.DataAccess.Abstract;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Concrete.EntityFramework
{
    public class EfPosterDal : EfEntityRepositoryBase<Poster, OnlineTicketContext>, IPosterDal
    {
    }
}
