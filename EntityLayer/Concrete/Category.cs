using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete;

public class Tag : BaseEntity
{
    public string? Name { get; set; }
    public string? CatergoryDescription { get; set; }
    public ICollection<Blog>? Blogs { get; set; }
}
