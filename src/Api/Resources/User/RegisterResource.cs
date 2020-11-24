using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources.User
{
    public class RegisterResource
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterResourceValidator : AbstractValidator<RegisterResource>
    {
        public RegisterResourceValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).NotNull();
            RuleFor(x => x.Surname).MaximumLength(50).NotNull();
            RuleFor(x => x.Email).EmailAddress().MaximumLength(50).NotNull();
            RuleFor(x => x.Password).MinimumLength(6).MaximumLength(50).NotNull();
        }
    }
}
