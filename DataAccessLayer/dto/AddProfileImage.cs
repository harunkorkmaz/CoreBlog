using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace WebUI.Models;

public class AddProfileImage
{
    public int Id { get; set; }
    public string WriterName { get; set; }
    public string WriterAbout { get; set; }
    public string WriterMail { get; set; }
    public string WriterPassword { get; set; }
    public string? WriterPasswordAgain { get; set; }
    public bool WriterStatus { get; set; }
    public IFormFile WriterImage { get; set; }
}
