using CourseProject2022FallBL.Models;

namespace CourseProject2022FallBL.Services
{
    public static class DataService
    {
        #region User

        public static bool AddUser(User user)
        {
            return SqlServerCrud.AddUser(user);
        }

        public static User GetUser(int ID)
        {
            return SqlServerCrud.GetUser(ID);
        }

        public static List<User> GetUsers()
        {
            return SqlServerCrud.GetUsers();
        }

        public static int GetUserID(User user)
        {
            return SqlServerCrud.GetUserID(user);
        }

        #endregion

        #region Target

        public static bool AddTarget(Target target)
        {
            return SqlServerCrud.AddTarget(target);
        }

        public static Target GetTarget(int ID)
        {
            return SqlServerCrud.GetTarget(ID);
        }

        public static List<Target> GetTargets()
        {
            return SqlServerCrud.GetTargets();
        }

        public static int GetTargetID(Target target)
        {
            return SqlServerCrud.GetTargetID(target);
        }

        #endregion

        #region Currency

        public static bool AddCurrency(Currency currency)
        {
            return SqlServerCrud.AddCurrency(currency);
        }

        public static Currency GetCurrency(int ID)
        {
            return SqlServerCrud.GetCurrency(ID);
        }

        public static List<Currency> GetCurrencies()
        {
            return SqlServerCrud.GetCurrencies();
        }

        public static int GetCurrencyID(Currency currency)
        {
            return SqlServerCrud.GetCurrencyID(currency);
        }

        #endregion

        #region Operation

        public static bool AddOperation(Operation operation)
        {
            return SqlServerCrud.AddOperation(operation);
        }

        public static Operation GetOperation(int ID)
        {
            return SqlServerCrud.GetOperation(ID);
        }

        public static List<Operation> GetOperations()
        {
            return SqlServerCrud.GetOperations();
        }

        public static int GetOperationID(Operation operation)
        {
            return SqlServerCrud.GetOperationID(operation);
        }

        #endregion

        #region Income

        public static bool AddIncome(Income income)
        {
            return SqlServerCrud.AddIncome(income);
        }

        public static Income GetIncome(int ID)
        {
            return SqlServerCrud.GetIncome(ID);
        }

        public static List<Income> GetIncomes()
        {
            return SqlServerCrud.GetIncomes();
        }

        public static int GetIncomeID(Income income)
        {
            return SqlServerCrud.GetIncomeID(income);
        }

        #endregion

        #region Expense

        public static bool AddExpense(Expense expense)
        {
            return SqlServerCrud.AddExpense(expense);
        }

        public static Expense GetExpense(int ID)
        {
            return SqlServerCrud.GetExpense(ID);
        }

        public static List<Expense> GetExpenses()
        {
            return SqlServerCrud.GetExpenses();
        }

        public static int GetExpenseID(Expense expense)
        {
            return SqlServerCrud.GetExpenseID(expense);
        }

        #endregion

    }
}
