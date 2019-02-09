namespace EcoDim.Domain.Enumerations
{
    public class FlagCardEnum
    {
        #region Properties

        public static FlagCardEnum Master => new FlagCardEnum(1, "Master Card");
        public static FlagCardEnum Visa => new FlagCardEnum(2, "Visa");

        #endregion

        #region Constructors

        protected FlagCardEnum() { }

        protected FlagCardEnum(int value, string displayName) { }

        #endregion
    }
}
