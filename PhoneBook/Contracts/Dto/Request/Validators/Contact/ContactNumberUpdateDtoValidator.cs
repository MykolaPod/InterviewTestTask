using Contracts.Dto.Request.Contact;
using FluentValidation;

namespace Contracts.Dto.Request.Validators.Contact
{
    public class ContactNumberUpdateDtoValidator : AbstractValidator<ContactNumberUpdateDto>
    {
        public ContactNumberUpdateDtoValidator()
        {
            RuleFor(dto => dto.Number).NotEmpty();
        }
    }
}