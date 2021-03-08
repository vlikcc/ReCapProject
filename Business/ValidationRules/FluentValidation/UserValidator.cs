using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            
            //RuleFor(u => u.PasswordH).MinimumLength(8);
            //RuleFor(u => u.Password).MaximumLength(16);
            //RuleFor(u => u.Password).Must(u => ValidPassword(u)).WithMessage("Şifre en az 8 en fazla 16 karakter olmalıdır. Şifre büyük harf, küçük harf ve rakam içermelidir.");            
        }
        private bool ValidPassword(string password)
        {
            var rgx = new Regex("[a-zA-Z0-9]");
            return rgx.IsMatch(password);
        }
    }
}
