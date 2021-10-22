using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICountyService
    {
        IDataResult<List<County>> GetAll();
        IDataResult<List<County>> GetListByCityId(int cityId);
        IDataResult<County> Get(int countyId);
        IResult Add(County county);
        IResult Update(County county);
        IResult Delete(int countyId);
    }
}
