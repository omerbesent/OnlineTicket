using OnlineTicket.Business.Abstract;
using OnlineTicket.DataAccess.Abstract;
using OnlineTicket.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTicket.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { CategoryId = categoryId });
        }

        public Category Get(int categoryId)
        {
            return _categoryDal.Get(x => x.CategoryId == categoryId);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList().OrderBy(x => x.Ranking.Value).ToList();
        }

        public List<Category> GetListMainCategory()
        {
            return _categoryDal.GetList(x => x.MainCategoryId == 0);
        }

        public List<Category> GetListSubCategory(int categoryId)
        {
            return _categoryDal.GetList(x => x.MainCategoryId == categoryId);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
