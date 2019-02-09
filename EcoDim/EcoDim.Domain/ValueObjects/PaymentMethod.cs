using EcoDim.Core;
using EcoDim.Domain.Enumerations;

namespace EcoDim.Domain.ValueObjects
{
    public class PaymentMethod : ValueObject<PaymentMethod>
    {
        #region Properties

        public PaymentTypeEnum Type { get; private set; }

        #endregion

        #region Constructors

        #endregion

        #region Public Methods

        protected override bool EqualsCore(PaymentMethod other)
        {
            throw new System.NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
