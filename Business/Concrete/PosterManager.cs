using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class PosterManager : IPosterService
    {
        private IPosterDal _posterDal;
        public PosterManager(IPosterDal posterDal)
        {
            _posterDal = posterDal;
        }

        public IResult Add(Poster poster)
        {
            _posterDal.Add(poster);
            return new SuccessResult(Messages.PosterAdded);
        }

        public IResult Update(Poster poster)
        {
            _posterDal.Update(poster);
            return new SuccessResult(Messages.PosterAdded);
        }

        public IResult Delete(int posterId)
        {
            var deleted = _posterDal.Get(x => x.PosterId == posterId);
            _posterDal.Delete(deleted);
            return new SuccessResult(Messages.PosterDeleted);
        }

        public IDataResult<Poster> Get(int posterId)
        {
            return new SuccessDataResult<Poster>(_posterDal.Get(x => x.PosterId == posterId), Messages.PostersListed);
        }

        public IDataResult<List<Poster>> GetAll()
        {
            return new SuccessDataResult<List<Poster>>(_posterDal.GetList().OrderBy(x => x.Ranking).ToList(), Messages.PostersListed);
        } 

    }
}
