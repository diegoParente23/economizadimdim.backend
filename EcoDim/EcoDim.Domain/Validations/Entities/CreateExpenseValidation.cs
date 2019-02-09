using EcoDim.Domain.Entities;
using FluentValidator.Validation;

namespace EcoDim.Domain.Validations.Entities
{
    public class CreateExpenseValidation : IContract
    {
        public ValidationContract Contract { get; private set; }

        public CreateExpenseValidation(Expense expense)
        {
            Contract = new ValidationContract();

            if (expense == null)
                Contract.AddNotification(nameof(Expense), $"{nameof(Expense)} not null");
            else
            {
                // TODO Make the validations here
            }
        }
    }
}
