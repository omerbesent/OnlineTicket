using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICountyService
    {
        List<County> GetAll();
        List<County> GetListByCityId(int cityId);
        County Get(int countyId);
        void Add(County county);
        void Update(County county);
        void Delete(int countyId);
    }
}
