namespace EcoDim.Core
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        #region Constructors

        protected ValueObject() { }

        #endregion

        #region Abstract Methods

        protected abstract bool EqualsCore(T other);

        protected abstract int GetHashCodeCore();

        #endregion

        #region Public Methods

        public static bool operator ==(ValueObject<T> objetoA,
            ValueObject<T> objetoB)
        {
            if (ReferenceEquals(objetoA, null) && ReferenceEquals(objetoB, null))
                return true;

            if (ReferenceEquals(objetoA, null) || ReferenceEquals(objetoB, null))
                return false;

            return objetoA.Equals(objetoB);
        }

        public static bool operator !=(ValueObject<T> objetoA,
            ValueObject<T> objetoB)
        {
            return !(objetoA == objetoB);
        }

        public override bool Equals(object obj)
        {
            var objDeValor = obj as T;

            if (ReferenceEquals(objDeValor, null))
                return false;

            return EqualsCore(objDeValor);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        public object Clone()
            => this.MemberwiseClone();

        #endregion
    }
}
