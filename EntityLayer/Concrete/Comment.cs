using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete;

public class Comment : BaseEntity
{
    public string Commenter { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public int Score { get; set; }
    public bool IsUser { get; set; }
    public int? BlogId { get; set; }
    public Blog? Blog { get; set; }
    public int? WriterId { get; set; }
    public int? UserId { get; set; }
    public AppUser? User { get; set; }


}