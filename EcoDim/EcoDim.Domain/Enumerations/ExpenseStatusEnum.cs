namespace EcoDim.Core.Domain.Enumerations
{
    public class ExpenseStatusEnum : Enumeration
    {
        #region Properties

        public static ExpenseStatusEnum Outstanding => new ExpenseStatusEnum(0, "Outstanding");
        public static ExpenseStatusEnum Paid => new ExpenseStatusEnum(1, "Paid");
        public static ExpenseStatusEnum Cancelled => new ExpenseStatusEnum(2, "Cancelled");

        #endregion

        #region Constructors

        protected ExpenseStatusEnum() { }

        protected ExpenseStatusEnum(int value, string displayName) { }

        #endregion
    }
}
