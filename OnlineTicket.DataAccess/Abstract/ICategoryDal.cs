using Entities.Concrete;
using Core.DataAccess;

namespace OnlineTicket.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //Custom Operations
    }
}
