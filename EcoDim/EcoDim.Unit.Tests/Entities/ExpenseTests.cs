using EcoDim.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EcoDim.Unit.Tests.Entities
{
    [TestClass]
    [TestCategory("Entities")]
    public class ExpenseTests
    {
        public ExpenseTests()
        {
        }

        [TestMethod]
        public void CreateExpenseSuccess()
        {
            var expense = Expense.New("Jogo de PS4", "Jogo do FIFA 19 para PS4",)
        }
    }
}
