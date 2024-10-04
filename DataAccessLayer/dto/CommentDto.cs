using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentUserName { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Score { get; set; }
        public int BlogId { get; set; }
        public int? WriterId { get; set; }
    }
}
