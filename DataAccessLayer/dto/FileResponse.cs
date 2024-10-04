using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.dto;

public class FileResponse
{
    public bool IsSuccess { get; set; }
    public byte[] FileContents { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public string Extension { get; set; }
    public double FileSize { get; set; }
    public string OriginalFileName { get; set; }
    public MemoryStream FileStream { get; set; }
}
