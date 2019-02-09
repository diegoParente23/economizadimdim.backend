namespace EcoDim.Domain.Enumerations
{
    public class PaymentTypeEnum
    {
        #region Properties

        public static PaymentTypeEnum Money => new PaymentTypeEnum(1, "Money");
        public static PaymentTypeEnum CreditCard => new PaymentTypeEnum(2, "Credit Card");
        public static PaymentTypeEnum DebitCard => new PaymentTypeEnum(3, "Debit Card");

        #endregion

        #region Constructors

        protected PaymentTypeEnum() { }

        protected PaymentTypeEnum(int value, string displayName) { }

        #endregion
    }
}
