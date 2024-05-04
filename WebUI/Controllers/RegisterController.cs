using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class RegisterController : Controller
{
    WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    private readonly UserManager<AppUser> _userManger;
    private readonly IMapper _mapper;

    public RegisterController(UserManager<AppUser> userManger, IMapper mapper)
    {
        _userManger = userManger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterDto p)
    {
        WriterValidator vw = new();
        ValidationResult results = vw.Validate(p);
        if (results.IsValid)
        {
            Writer _mappedPerson = _mapper.Map<Writer>(p);

            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var loc = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(loc, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                _mappedPerson.WriterImage = "/WriterImageFiles/" + newImageName;
            }
            else
                _mappedPerson.WriterImage = "/writer/assets/images/faces-clipart/pic-" + new Random().Next(1, 4) + ".png";

            _writerManager.TAdd(_mappedPerson);

            AppUser user = new AppUser()
            {
                Email = _mappedPerson.WriterMail,
                FullName = _mappedPerson.WriterName,
                UserName = _mappedPerson.WriterName,
                ImageUrl = _mappedPerson.WriterImage
            };

            var result = await _userManger.CreateAsync(user, _mappedPerson.WriterPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }
}
