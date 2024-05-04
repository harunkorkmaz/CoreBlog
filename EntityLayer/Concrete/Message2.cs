using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        public Message2()
        {
            //ReceiverUser
        }
        [Key]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime Date { get; set; } = Convert.ToDateTime(DateTime.UtcNow);
        public bool Status { get; set; }
        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
