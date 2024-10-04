using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract;

public interface ICurrentUserService
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Eposta { get; }
    public string Phone { get; }
    public string ConcurrencyStamp { get; }
}