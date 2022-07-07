using FluentValidation;

namespace ManagerHairdresser.Domain.Entities.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório")
                .NotNull().WithMessage("O nome do cliente é obrigatório")
                .Length(2, 100).WithMessage("O nome do cliente deve ter entre 2 e 100 caracteres");
        }
    }
}
