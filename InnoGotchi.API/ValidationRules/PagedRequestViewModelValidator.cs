using FluentValidation;
using InnoGotchi.Shared.Paging;

namespace InnoGotchi.API.ValidationRules
{
    public class PagedRequestViewModelValidator : AbstractValidator<PagedRequest>
    {
        public PagedRequestViewModelValidator()
        {
            RuleFor(p => p.PageNumber)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.PageSize)
                .NotNull()
                .GreaterThan(0)
                .LessThan(20);
        }
    }
}
