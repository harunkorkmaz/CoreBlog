using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.dto;

public class UserSignInViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
