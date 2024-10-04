using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.dto.Responses;

public class JwtTokenDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Eposta { get; set; }
    public string Phone { get; set; }
    public string ConcurrencyStamp { get; set; }
}
