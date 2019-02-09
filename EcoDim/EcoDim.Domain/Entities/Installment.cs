using EcoDim.Core;
using EcoDim.Core.Domain.Enumerations;
using Newtonsoft.Json;
using System;

namespace EcoDim.Domain.Entities
{
    public class Installment : Entity
    {
        #region Properties

        public decimal Value { get; private set; }

        public DateTime PaymentDate { get; private set; }

        public ExpenseStatusEnum Status { get; private set; }

        #endregion

        #region Constructors

        [JsonConstructor]
        private Installment(Guid id, decimal value, DateTime paymentDate, ExpenseStatusEnum status)
            : base(id)
        {
            Value = value;
            PaymentDate = paymentDate;
            Status = status;
        }

        private Installment(decimal value, DateTime paymentDate)
            : this(Guid.Empty, value, paymentDate, ExpenseStatusEnum.Outstanding) { }

        #endregion

        #region Public Methods

        public override string ToString()
            => $"{PaymentDate.ToLongDateString()} - {Value.ToString("c")} - {Status.DisplayName}";

        public static Installment New(decimal value, DateTime paymentDate)
            => new Installment(value, paymentDate);

        #endregion
    }
}
