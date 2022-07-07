using FluentValidation;

namespace ManagerHairdresser.Domain.Entities.Validations
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(c => c.ItemId)
                .NotEmpty().WithMessage("O item é obrigatório.")
                .NotNull().WithMessage("O item é obrigatório.");
        }

    }
}
