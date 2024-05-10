using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>
    {
        public List<Message2> GetInboxMessageByWriter(int id)
        {
            using (var item = new Context())
            {
                return item.Message2s
                    .Include(x => x.SenderUser)
                    .Where(x => x.RecieverId == id)
                    .ToList();
            }
        }

        public List<Message2> GetSendboxMessageByWriter(int id)
        {
            using (var item = new Context())
            {
                return item.Message2s
                    .Include(x => x.ReceiverUser)
                    .Where(x => x.SenderId == id)
                    .ToList();
            }
        }
    }
}
