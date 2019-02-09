using System;

namespace EcoDim.Core
{
    public abstract class Entity
    {
        #region Properties

        public Guid Id
        {
            get => id;
            protected set => id = (value == Guid.Empty) ? Guid.NewGuid() : id;
        }

        public DateTime CreatedIn { get; protected set; }

        #endregion

        #region Fields

        private Guid id;

        #endregion

        #region Constructors

        protected Entity(Guid id)
        {
            Id = id;
            CreatedIn = DateTime.Now;
        }

        protected Entity()
            :this(Guid.NewGuid()) { }

        #endregion

        #region Public Methods

        public static bool operator ==(Entity entityA, Entity entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entity entityA, Entity entityB)
        {
            return !(entityA == entityB);
        }

        public override bool Equals(object entity)
        {
            var entidadeComparacao = entity as Entity;

            if (ReferenceEquals(entidadeComparacao, null))
                return false;

            if (ReferenceEquals(this, entidadeComparacao))
                return true;

            if (GetType() != entidadeComparacao.GetType())
                return false;

            return Id == entidadeComparacao.Id;
        }

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();

        public object Clone()
            => this.MemberwiseClone();

        #endregion
    }
}
