using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete;

public class Blog : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? BlogImage { get; set; }
    public int? UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Tag>? Tags { get; set; }
}
