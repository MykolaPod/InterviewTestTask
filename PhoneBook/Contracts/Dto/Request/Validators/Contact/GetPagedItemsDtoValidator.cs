using Contracts.Dto.Request.Contact;
using FluentValidation;

namespace Contracts.Dto.Request.Validators.Contact
{
    public class GetPagedItemsDtoValidator : AbstractValidator<GetPagedItemsDto>
    {
        public GetPagedItemsDtoValidator()
        {
            RuleFor(dto => dto.Page).NotEmpty();
            RuleFor(dto => dto.PageSize).NotEmpty();
        }
    }
}