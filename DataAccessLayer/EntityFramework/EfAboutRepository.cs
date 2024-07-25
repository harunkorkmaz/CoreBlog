using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAboutRepository(BlogContext blogContext)
{
    public List<About> GetListAll()
    {
        return [.. blogContext.Abouts];
    }

}
