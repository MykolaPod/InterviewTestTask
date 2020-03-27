using Contracts.Dto.Request.Contact;
using FluentValidation;

namespace Contracts.Dto.Request.Validators.Contact
{
    public class ContactNumberCreateDtoValidator : AbstractValidator<ContactNumberCreateDto>
    {
        public ContactNumberCreateDtoValidator()
        {
            RuleFor(dto => dto.Number).NotEmpty();
        }
    }
}