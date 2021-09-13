using OnlineTicket.Entities.Concrete;
using System.Collections.Generic;

namespace OnlineTicket.Business.Abstract
{
    public interface IPosterService
    {
        List<Poster> GetAll();
        Poster Get(int posterId);
        void Add(Poster poster);
        void Update(Poster poster);
        void Delete(int posterId);
    }
}
