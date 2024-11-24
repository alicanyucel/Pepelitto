using FluentValidation;
using Pepelitto.Application.Features.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Application.Features.User.Createuser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .MinimumLength(2)
                .WithMessage("Kullanıcı adı en az  2 karakter olmalıdır");
            RuleFor(p => p.LastName)
                .MinimumLength(2)
                .WithMessage("Soyisim en az 2 karakter olmalıdır");
            RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email adresinizi giriniz.")
          .EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");
            RuleFor(p => p.Phone)
            .MinimumLength(11)
            .WithMessage("telefon numaranızı 11 hane giriniz");
            RuleFor(p => p.Phone)
           .MaximumLength(11).WithMessage("Telefon numaranız 11 haneyi geçemez.");
            RuleFor(p => p.City).MinimumLength(3).WithMessage("il adı en az 3 harften oluşmalıdır ornek mus");
            RuleFor(p => p.Town).MinimumLength(2).WithMessage("ilçe adı en az 2 harften oluşmalıdır");
            RuleFor(p => p.Address).MinimumLength(10).WithMessage("açık adresinizi giriniz en az 10 harf olmalıdır");

        }
    }
}
