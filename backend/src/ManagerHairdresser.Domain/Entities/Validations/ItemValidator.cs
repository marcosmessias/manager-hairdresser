using FluentValidation;

namespace ManagerHairdresser.Domain.Entities.Validations
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do item é obrigatório.")
                .NotNull().WithMessage("O nome do item é obrigatório.")
                .Length(2, 100).WithMessage("O nome do item deve ter entre 2 e 100 caracteres.");

            RuleFor(c => c.OutputPrice)
                .NotNull().WithMessage("O nome do item é obrigatório.");
        }
    }
}
