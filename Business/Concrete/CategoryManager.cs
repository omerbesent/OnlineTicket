using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult Delete(int categoryId)
        {
            var deleteCategory = _categoryDal.Get(x => x.CategoryId == categoryId);
            _categoryDal.Delete(deleteCategory);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<Category> Get(int categoryId)
        {
            var get = _categoryDal.Get(x => x.CategoryId == categoryId);
            return new SuccessDataResult<Category>(get, Messages.CategoriesListed);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var list = _categoryDal.GetList().OrderBy(x => x.Ranking.Value).ToList();
            return new SuccessDataResult<List<Category>>(list, Messages.CategoriesListed);
        }

        public IDataResult<List<Category>> GetListMainCategory()
        {
            var list = _categoryDal.GetList(x => x.MainCategoryId == 0);
            return new SuccessDataResult<List<Category>>(list, Messages.CategoriesListed);
        }

        public IDataResult<List<Category>> GetListSubCategory(int categoryId)
        {
            var list = _categoryDal.GetList(x => x.MainCategoryId == categoryId);
            return new SuccessDataResult<List<Category>>(list, Messages.CategoriesListed);
        }

    }
}
