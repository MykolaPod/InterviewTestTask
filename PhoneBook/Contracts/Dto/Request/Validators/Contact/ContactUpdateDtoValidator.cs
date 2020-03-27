using Contracts.Dto.Request.Contact;
using FluentValidation;

namespace Contracts.Dto.Request.Validators.Contact
{
    public class ContactUpdateDtoValidator : AbstractValidator<ContactUpdateDto>
    {
        public ContactUpdateDtoValidator()
        {
            RuleFor(dto => dto.Id).NotEmpty();
            RuleFor(dto => dto.Name).NotEmpty();
            RuleFor(dto => dto.Address).NotEmpty();
            RuleFor(dto => dto.BirthDate).NotEmpty();
            RuleFor(dto => dto.ContactNumbers).NotEmpty();
        }
    }
}