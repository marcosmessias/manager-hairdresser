using FluentValidation;

namespace ManagerHairdresser.Domain.Entities.Validations
{
    public class ItemTypeValidator : AbstractValidator<ItemType>
    {
        public ItemTypeValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do tipo de item é obrigatório.")
                .NotNull().WithMessage("O nome do tipo de item é obrigatório.")
                .Length(2, 100).WithMessage("O nome do tipo de item deve ter entre 2 e 100 caracteres.");
        }
    }
}
