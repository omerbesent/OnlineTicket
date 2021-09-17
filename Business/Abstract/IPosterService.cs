using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPosterService
    {
        IDataResult<List<Poster>> GetAll();
        IDataResult<Poster> Get(int posterId);
        IResult Add(Poster poster);
        IResult Update(Poster poster);
        IResult Delete(int posterId);
    }
}
