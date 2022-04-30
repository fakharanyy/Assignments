using FluentValidation;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.Presentation.ModelValidation
{
    public class CustomerModelValidator: AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(e => e.Name).Length(5, 50).NotNull();
            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.PhoneNumber).NotNull();
            RuleFor(e => e.Comment).Length(0, 250);
            //RuleFor(e => e.Class).NotNull().IsInEnum();
        }
    }
}
 