using FluentValidation;

namespace ManagerHairdresser.Domain.Entities.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty().WithMessage("O cliente é obrigatório.")
                .NotNull().WithMessage("O cliente é obrigatório.");
        }

    }
}
