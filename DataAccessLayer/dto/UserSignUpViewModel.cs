using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.dto;

public class UserSignUpViewModel
{
    [Display(Name = "Name Surname")]
    [Required(ErrorMessage = "Please enter Name and Surname!")]
    public string FullName { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Please enter Password!")]
    public string Password { get; set; }

    [Display(Name = "Mail")]
    [Required(ErrorMessage = "Please enter Mail Address!")]
    public string Mail { get; set; }

    [Display(Name = "User Name")]
    [Required(ErrorMessage = "Please enter User Name!")]
    public string UserName { get; set; }

    [Display(Name = "Again Password")]
    [Compare("Password", ErrorMessage = "Passwords don't match!")]
    public string ConfirmPassword { get; set; }
}
