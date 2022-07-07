using FluentValidation;

namespace ManagerHairdresser.Domain.Entities.Validations
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.OrderId)
                .NotEmpty().WithMessage("O pedido é obrigatória.")
                .NotNull().WithMessage("O pedido é obrigatória.");

            RuleFor(c => c.PaymentTypeId)
                .NotEmpty().WithMessage("O tipo de pagamento é obrigatório.")
                .NotNull().WithMessage("O tipo de pagamento é obrigatório.");

            RuleFor(c => c.WasPaid)
                .NotEmpty().WithMessage("O status do pagamento é obrigatório.")
                .NotNull().WithMessage("O status do pagamento é obrigatório.");

            RuleFor(c => c.PaymentForecastDate)
                .NotEmpty().WithMessage("A data de previsão do pagamento é obrigatória.")
                .NotNull().WithMessage("A data de previsão do pagamento é obrigatória.");

            RuleFor(c => c.PaymentForecastDate)
                .Must(ValidatetDate)
                .WithMessage("A data de previsão do pagamento é inválida.");

            RuleFor(c => c.PaymentDate)
                .NotEmpty().WithMessage("A data do pagamento é obrigatória.")
                .NotNull().WithMessage("A data do pagamento é obrigatória.");

            RuleFor(c => c.PaymentDate)
                .GreaterThanOrEqualTo(c => c.PaymentForecastDate).WithMessage("A data do pagamento deve ser maior ou igual a data de previsão do pagamento.");

            RuleFor(c => c.PaymentDate)
                .Must(ValidatetDate)
                .WithMessage("A data de pagamento é inválida.");

            RuleFor(c => c)
                .Must(ValidatePaymentType)
                .WithMessage("O tipo de pagamento não é válido.");

        }

        private bool ValidatetDate(DateTime date)
        {
            return date != DateTime.MaxValue && date != DateTime.MinValue;
        }

        private bool ValidatePaymentType(Payment payment)
        {
            if (payment.PaymentTypeId == 1 && payment.WasPaid == 0)
            {
                return false;
            }
            return true;
        }

    }
}
