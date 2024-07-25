using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNewsLetterRepository(BlogContext context) 
    {
        public void Insert(NewsLetter newsLetter)
        {
            context.NewsLetters.Add(newsLetter);
            context.SaveChanges();
        }
    }
}
