using OnlineTicket.Entities.Concrete;
using System.Collections.Generic;

namespace OnlineTicket.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetListMainCategory();
        List<Category> GetListSubCategory(int categoryId);
        Category Get(int categoryId);
        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
    }
}