using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EntityLayer.Dto;

public class RegisterDto
{
    public int Id { get; set; }
    public string WriterName { get; set; }
    public string WriterMail { get; set; }
    public string WriterPassword { get; set; }
    public string? WriterPasswordAgain { get; set; }
    public bool WriterStatus { get; set; }
    public IFormFile WriterImage { get; set; }
}

// validator

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
        RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
        RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
        RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
        RuleFor(x => x.WriterPasswordAgain).NotEmpty().WithMessage("Şifre tekrarı boş geçilemez");
        RuleFor(x => x.WriterPasswordAgain).Equal(x => x.WriterPassword).WithMessage("Şifreler uyuşmuyor");
    }
}

