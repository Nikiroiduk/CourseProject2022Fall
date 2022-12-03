using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;

namespace CourseProject2022FallxUnitTest
{
    public class DataGeneratorTests
    {
        [Fact]
        public void GenerateUser_False()
        {
            var user = new User();

            user = DataGenerator.testUsers.Generate();

            Assert.False(user.isDefault, "User parameters is'n different from default values");
        }

        [Fact]
        public void GenerateTarget_False()
        {
            var target = new Target();

            target = DataGenerator.testTargets.Generate();

            Assert.False(target.isDefault, "Target parameters is'n different from default values");
        }

        [Fact]
        public void GenerateCurrency_False()
        {
            var currency = new Currency();

            currency = DataGenerator.testCurrencies.FirstOrDefault();

            Assert.False(currency.isDefault, "Currency parameters is'n different from default values");
        }

        [Fact]
        public void GenerateOperation_False()
        {
            var operation = new Operation();

            operation = DataGenerator.testOperations.Generate();

            Assert.False(operation.isDefault, "Operation parameters is'n different from default values");
        }

        [Fact]
        public void GenerateIncome_False()
        {
            var income = new Income();

            income = DataGenerator.testIncomes.Generate();

            Assert.False(income.isDefault, "Income parameters is'n different from default values");
        }

        [Fact]
        public void GenerateExpense_False()
        {
            var expense = new Expense();

            expense = DataGenerator.testExpenses.Generate();

            Assert.False(expense.isDefault, "Expense parameters is'n different from default values");
        }
    }
}
