using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.SqlServer;
using Action = CourseProject2022FallBL.Models.Action;


namespace CourseProject2022FallBL.Services
{
    public static class DataService
    {
        #region User

        public static bool AddUser(User user)
        {
            return SqlServerCrud.AddUser(user);
        }

        public static bool AddUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (!UpsertUser(user)) return false;
            }
            return true;
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

        public static bool UpdateUser(User user)
        {
            return SqlServerCrud.UpdateUser(user);
        }

        public static bool RemoveUser(User user)
        {
            return SqlServerCrud.RemoveUser(user);
        }

        public static bool UpsertUser(User user)
        {
            if (GetUserID(user) == 0)
                return AddUser(user);
            else
                return UpdateUser(user);
        }

        public static bool RemoveAllDataInUserTable()
        {
            return SqlServerCrud.RemoveAllDataInUserTable();
        }

        #endregion

        #region Target

        public static bool AddTarget(Target target)
        {
            return SqlServerCrud.AddTarget(target);
        }

        public static bool AddTargets(List<Target> targets)
        {
            foreach (var target in targets)
            {
                if (!UpsertTarget(target)) return false;
            }
            return true;
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

        public static bool UpdateTarget(Target target)
        {
            return SqlServerCrud.UpdateTarget(target);
        }

        public static bool RemoveTarget(Target target)
        {
            return SqlServerCrud.RemoveTarget(target);
        }

        public static bool UpsertTarget(Target target)
        {
            if (GetTargetID(target) == 0)
                return AddTarget(target);
            else
                return UpdateTarget(target);
        }

        #endregion

        #region Currency

        public static bool AddCurrency(Currency currency)
        {
            return SqlServerCrud.AddCurrency(currency);
        }

        public static bool AddCurrencies(List<Currency> currencies)
        {
            foreach (var currency in currencies)
            {
                if (!UpsertCurrency(currency)) return false;
            }
            return true;
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

        public static bool UpdateCurrency(Currency currency)
        {
            return SqlServerCrud.UpdateCurrency(currency);
        }

        public static bool RemoveCurrency(Currency currency)
        {
            return SqlServerCrud.RemoveCurrency(currency);
        }

        public static bool UpsertCurrency(Currency currency)
        {
            if (GetCurrencyID(currency) == 0)
                return AddCurrency(currency);
            else
                return UpdateCurrency(currency);
        }

        #endregion

        #region Operation

        public static bool AddOperation(Operation operation)
        {
            return SqlServerCrud.AddOperation(operation);
        }

        public static bool AddOperations(List<Operation> operations)
        {
            foreach (var operation in operations)
            {
                if (!UpsertOperation(operation)) return false;
            }
            return true;
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

        public static bool UpdateOperation(Operation operation)
        {
            return SqlServerCrud.UpdateOperation(operation);
        }

        public static bool RemoveOperation(Operation operation)
        {
            return SqlServerCrud.RemoveOperation(operation);
        }

        public static bool UpsertOperation(Operation operation)
        {
            if (GetOperationID(operation) == 0)
                return AddOperation(operation);
            else
                return UpdateOperation(operation);
        }

        #endregion

        #region Income

        public static bool AddIncome(Income income)
        {
            return SqlServerCrud.AddIncome(income);
        }

        public static bool AddIncomes(List<Income> incomes)
        {
            foreach (var income in incomes)
            {
                if (!UpsertIncome(income)) return false;
            }
            return true;
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

        public static bool RemoveIncome(Income income)
        {
            return SqlServerCrud.RemoveIncome(income);
        }

        public static bool UpdateIncome(Income income)
        {
            return SqlServerCrud.UpdateIncome(income);
        }

        public static bool UpsertIncome(Income income)
        {
            if (GetIncomeID(income) == 0)
                return AddIncome(income);
            else
                return UpdateIncome(income);
        }

        #endregion

        #region Expense

        public static bool AddExpense(Expense expense)
        {
            return SqlServerCrud.AddExpense(expense);
        }

        public static bool AddExpenses(List<Expense> expenses)
        {
            foreach (var expense in expenses)
            {
                if (!UpsertExpense(expense)) return false;
            }
            return true;
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

        public static bool RemoveExpense(Expense expense)
        {
            return SqlServerCrud.RemoveExpense(expense);
        }

        public static bool UpdateExpense(Expense expense)
        {
            return SqlServerCrud.UpdateExpense(expense);
        }

        public static bool UpsertExpense(Expense expense)
        {
            if (GetExpenseID(expense) == 0)
                return AddExpense(expense);
            else
                return UpdateExpense(expense);
        }

        public static bool RemoveAllDataInExpenseTable()
        {
            return SqlServerCrud.RemoveAllDataInExpenseTable();
        }

        #endregion

        #region Action

        public static List<Action> GetActions()
        {
            return SqlServerCrud.GetActions();
        }

        #endregion

        public static bool RemoveAllDataFromTables()
        {
            return SqlServerCrud.RemoveAllDataFromTables();
        }

    }
}
