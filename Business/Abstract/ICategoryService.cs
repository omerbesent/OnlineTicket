using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetListMainCategory();
        IDataResult<List<Category>> GetListSubCategory(int categoryId);
        IDataResult<Category> Get(int categoryId);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(int categoryId);
    }
}