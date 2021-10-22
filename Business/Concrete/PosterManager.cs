using Business.Abstract;
using Business.Constans;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Business.Concrete
{
    public class PosterManager : IPosterService
    {
        private IPosterDal _posterDal;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PosterManager(IPosterDal posterDal, IHostingEnvironment hostingEnvironment)
        {
            _posterDal = posterDal;
            _hostingEnvironment = hostingEnvironment;
        }

        [TransactionScopeAspect]
        public IResult Add(PosterDto posterDto)
        {
            var result = BusinessRules.Run(
                CheckIfEventWebImage(posterDto.WebImage),
                CheckIfEventMobileImage(posterDto.MobilImage));
            if (result != null)
            {
                return result;
            }

            var fileWeb = posterDto.WebImage;
            var fileNameWeb = string.Format("PosterWeb_{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmss_" + new Random().Next(100, 999)));
            var filePathWeb = string.Format(@"{0}\assets\Posters\{1}", _hostingEnvironment.ContentRootPath, fileNameWeb);
            using (var stream = System.IO.File.Create(filePathWeb))
            {
                fileWeb.CopyTo(stream);
            }

            var fileMob = posterDto.MobilImage;
            var fileNameMob = string.Format("PosterMobil_{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmss_" + new Random().Next(100, 999)));
            var filePathMob = string.Format(@"{0}\assets\Posters\{1}", _hostingEnvironment.ContentRootPath, fileNameMob);
            using (var stream = System.IO.File.Create(filePathMob))
            {
                fileMob.CopyTo(stream);
            }

            var poster = new Poster();
            poster.Title = posterDto.Title;
            poster.Link = posterDto.Link;
            poster.Path = @"\assets\Posters";
            poster.FileName = fileNameWeb;
            poster.MobileFileName = fileNameMob;
            poster.Active = Convert.ToBoolean(posterDto.Active);
            poster.CreateDate = DateTime.Now;
            poster.CreatedBy = 1;

            _posterDal.Add(poster);
            return new SuccessResult(Messages.PosterAdded);
        }

        [TransactionScopeAspect]
        public IResult Update(PosterDto posterDto)
        {
            var poster = _posterDal.Get(x => x.PosterId == posterDto.PosterId);
            if (poster == null)
                return new ErrorResult(Messages.RecordNotFoundError);


            string fileNameWeb = "";
            if (posterDto.WebImage != null)
            {
                var result = BusinessRules.Run(CheckIfEventWebImage(posterDto.WebImage));
                if (result != null)
                {
                    return result;
                }

                var fileWeb = posterDto.WebImage;
                fileNameWeb = string.Format("PosterWeb_{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmss_" + new Random().Next(100, 999)));
                var filePathWeb = string.Format(@"{0}\assets\Posters\{1}", _hostingEnvironment.ContentRootPath, fileNameWeb);
                using (var stream = System.IO.File.Create(filePathWeb))
                {
                    fileWeb.CopyTo(stream);
                }
            }
            else
                fileNameWeb = poster.FileName;

            string fileNameMob = "";
            if (posterDto.MobilImage != null)
            {
                var result = BusinessRules.Run(CheckIfEventMobileImage(posterDto.MobilImage));
                if (result != null)
                {
                    return result;
                }

                var fileMob = posterDto.MobilImage;
                fileNameMob = string.Format("PosterMob_{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmss_" + new Random().Next(100, 999)));
                var filePathMob = string.Format(@"{0}\assets\Posters\{1}", _hostingEnvironment.ContentRootPath, fileNameMob);
                using (var stream = System.IO.File.Create(filePathMob))
                {
                    fileMob.CopyTo(stream);
                }
            }
            else
                fileNameMob = poster.MobileFileName;

            poster.Title = posterDto.Title;
            poster.Link = posterDto.Link;
            poster.Path = @"\assets\Posters";
            poster.FileName = fileNameWeb;
            poster.MobileFileName = fileNameMob;
            poster.Active = Convert.ToBoolean(posterDto.Active);
            poster.UpdateDate = DateTime.Now;
            poster.UpdatedBy = 1;

            _posterDal.Update(poster);
            return new SuccessResult(Messages.PosterUpdated);
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



        //Check
        private IResult CheckIfEventWebImage(IFormFile file)
        {
            if (file == null)
                return new ErrorResult(Messages.WebImageSelectedError);

            if (file.ContentType.Substring(0, 6) != "image/")
                return new ErrorResult(Messages.NotImageError);

            using (var image = Image.FromStream(file.OpenReadStream()))
            {
                if (image.Width != 1140 && image.Height != 450)
                    return new ErrorResult(Messages.PosterWebImageSizeError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfEventMobileImage(IFormFile file)
        {
            if (file == null)
                return new ErrorResult(Messages.MobilImageSelectedError);

            if (file.ContentType.Substring(0, 6) != "image/")
                return new ErrorResult(Messages.NotImageError);

            using (var image = Image.FromStream(file.OpenReadStream()))
            {
                if (image.Width != 375 && image.Height != 300)
                    return new ErrorResult(Messages.PosterMobileImageSizeError);
            }

            return new SuccessResult();
        }

    }
}
