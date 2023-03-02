﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager: IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetAllBlogs()
        {
            return _blogDal.GetAll();
        }
        public Blog GetBlogById(int id)
        {
            return _blogDal.GetById(id);
        }
        public void BlogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }
        public void BlogDelete(Blog blog)
        {
            throw new NotImplementedException();
        }
        public void BlogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
