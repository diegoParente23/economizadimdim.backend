namespace EcoDim.Core.Shared.Enumerations
{
    public class ActiveEnum : Enumeration
    {
        #region Properties

        public static ActiveEnum Active => new ActiveEnum(0, "Active");
        public static ActiveEnum Inactive => new ActiveEnum(1, "Inactive");

        #endregion

        #region Constructors

        protected ActiveEnum() { }

        protected ActiveEnum(int value, string displayName) { }

        #endregion
    }
}
