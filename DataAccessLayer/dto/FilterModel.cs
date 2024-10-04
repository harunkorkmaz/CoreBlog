using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.dto;

public class FilterModel
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 9;
    public string? Search { get; set; }
    public OrderBy? OrderBy { get; set; }
}

public enum OrderBy
{
    [Description("Artan")]
    Ascending = 1,
    [Description("Azalan")]
    Descending = 2
}
