using EcoDim.Core;
using EcoDim.Core.Shared.Enumerations;
using EcoDim.Domain.Enumerations;
using System;

namespace EcoDim.Domain.Entities
{
    public class CreditCard : Entity
    {
        #region Properties

        public FlagCardEnum FlagCard { get; private set; }

        public DateTime Expiration { get; private set; }

        public ActiveEnum Active { get; private set; }

        public decimal Limit { get; private set; }

        #endregion

        #region Constructors

        #endregion

        #region Public Methods

        #endregion
    }
}
