using EcoDim.Core;
using EcoDim.Core.Domain.Enumerations;
using EcoDim.Domain.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcoDim.Domain.Entities
{
    public class Expense : Entity
    {
        #region Properties

        public string Title { get; private set; }

        public string Description { get; private set; }

        public ExpenseStatusEnum Status { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public decimal Value { get; private set; }

        public DateTime Date
        {
            get => date;
            private set => date = (value != null) ? value.Date : DateTime.MinValue;
        }

        public IReadOnlyList<Installment> Installments
        {
            get => installments.ToList();
            private set => installments = value.ToList();
        }

        public bool IsInstallment => Installments.Count() > 0;

        public int NumberOfInstallments => Installments.Count();

        #endregion

        #region Fields

        private IList<Installment> installments;
        private decimal value;
        private DateTime date;

        #endregion

        #region Constructors

        [JsonConstructor]
        private Expense(Guid id, string title, string description,
            ExpenseStatusEnum status, PaymentMethod paymentMethod,
            DateTime date, IEnumerable<Installment> installments, decimal value)
            : base(id)
        {
            Title = title;
            Description = description;
            Status = status;
            PaymentMethod = paymentMethod;
            Date = date;
            Installments = installments as List<Installment> ?? new List<Installment>();
            Value = value;
        }

        private Expense(string title, string description, PaymentMethod paymentMethod,
            DateTime date, decimal value)
            : this(Guid.Empty, title, description, ExpenseStatusEnum.Outstanding, paymentMethod, date, null, value) { }

        #endregion

        #region Public Methods

        public override string ToString()
            => $"{Title} - {Value.ToString("c")} - {Status.DisplayName}";

        public static Expense New(string title, string description, PaymentMethod paymentMethod,
            DateTime date, decimal value)
            => new Expense(title, description, paymentMethod, date, value);

        #endregion
    }
}
