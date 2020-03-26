using Contracts.Dto.Request.Contact;
using FluentValidation;

namespace Contracts.Dto.Request.Validators.Contact
{
    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty();
        }
    }
}