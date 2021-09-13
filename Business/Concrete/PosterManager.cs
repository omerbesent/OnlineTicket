using Business.Abstract;
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
        public void Add(Poster poster)
        {
            _posterDal.Add(poster);
        }

        public void Delete(int posterId)
        {
            var poster = Get(posterId);
            _posterDal.Delete(poster);
        }

        public Poster Get(int posterId)
        {
            return _posterDal.Get(x => x.PosterId == posterId);
        }

        public List<Poster> GetAll()
        {
            return _posterDal.GetList().OrderBy(x => x.Ranking).ToList();
        }

        public void Update(Poster poster)
        {
            _posterDal.Update(poster);
        }
    }
}
