using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>
    {
        public List<Comment> GetAll(int blogId)
        {
            using (var context = new Context())
            {
                List<Comment> x = context.Comments.Where(x => x.BlogId == blogId).ToList();
                return x;
            }
        }

        public List<Comment> GetAll()
        {
            using (var context = new Context())
            {
                List<Comment> x = context.Comments.Include(x => x.Blog).ToList();
                return x;
            }
        }

        public List<Comment> GetAllwithUser(int blogId)
        {             
            using (var context = new Context())
            {
                List<Comment> x = context.Comments.Include(x => x.Writer).Where(x => x.BlogId == blogId).ToList();
                return x;
            }
        }
    }
}
