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
    public string? Url { get; set; }
    public int? UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Tag>? Tags { get; set; }
    public string? BlogImage { get; set; }
    public string? OriginalFileName { get; set; }
    public string? Extension { get; set; }
    public double? FileSizeByte { get; set; }
}

public class BlogResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string BlogImage { get; set; }
    public string Url { get; set; }
    public int UserId { get; set; }
    public string UserFullName { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Tag>? Tags { get; set; }
}
