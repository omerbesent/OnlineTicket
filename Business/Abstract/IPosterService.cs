using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPosterService
    {
        IDataResult<List<Poster>> GetAll();
        IDataResult<Poster> Get(int posterId);
        IResult Add(PosterDto posterDto);
        IResult Update(PosterDto posterDto);
        IResult Delete(int posterId);
    }
}
