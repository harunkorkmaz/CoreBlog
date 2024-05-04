using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetByIdd(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public List<Category> GetListWithBlogs()
        {
            return _categoryDal.GetListWithBlogs();
        }

        public void TAdd(Category t)
        {
            if (t.CategoryName != "" &&
                t.CatergoryDescription != "" &&
                //category.CategoryName.Length >= 5 &&
                t.CategoryStatus == true)
            {
                _categoryDal.Insert(t);
            }
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
