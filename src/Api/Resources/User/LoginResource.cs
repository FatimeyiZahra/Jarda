using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources.User
{
    public class LoginResource
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResourceValidator : AbstractValidator<LoginResource>
    {
        public LoginResourceValidator()
        {
            RuleFor(x => x.Email).EmailAddress().MaximumLength(50).NotNull();
            RuleFor(x => x.Password).MinimumLength(6).MaximumLength(50).NotNull();
        }
    }
}
