using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.SqlServer;
using System.Collections.Specialized;
using Action = CourseProject2022FallBL.Models.Action;


namespace CourseProject2022FallBL.Services
{
    public class DataService
    {

        #region User

        public static bool AddUser(User user, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.AddUser(user, InitialCatalog: InitialCatalog);
        }

        public static bool AddUsers(List<User> users, string InitialCatalog = "Finances")
        {
            foreach (var user in users)
            {
                if (!UpsertUser(user, InitialCatalog)) return false;
            }
            return true;
        }

        public static User GetUser(int ID, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetUser(ID, InitialCatalog);
        }

        public static List<User> GetUsers(string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetUsers(InitialCatalog);
        }

        public static int GetUserID(User user, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetUserID(user, InitialCatalog);
        }

        public static bool UpdateUser(User user, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.UpdateUser(user, InitialCatalog);
        }

        public static bool RemoveUser(User user, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.RemoveUser(user, InitialCatalog);
        }

        public static bool UpsertUser(User user, string InitialCatalog = "Finances")
        {
            if (user.ID == 0)
                return AddUser(user, InitialCatalog);
            else
                return UpdateUser(user, InitialCatalog);
        }

        public static bool RemoveAllDataInUserTable(string InitialCatalog = "Finances")
        {
            return SqlServerCrud.RemoveAllDataInUserTable(InitialCatalog);
        }

        public static List<Operation> GetIncomeExpenseDataByUser(User user, bool isIncome, string InitialCatalog = "Finances")
        {
            return SqlServerActions.GetIncomeExpenseDataByUser(user, isIncome);
        }

        #endregion

        #region Target

        public static bool AddTarget(Target target, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.AddTarget(target, InitialCatalog);
        }

        public static bool AddTargets(List<Target> targets, string InitialCatalog = "Finances")
        {
            foreach (var target in targets)
            {
                if (!UpsertTarget(target, InitialCatalog)) return false;
            }
            return true;
        }

        public static Target GetTarget(int ID, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetTarget(ID, InitialCatalog);
        }

        public static List<Target> GetTargets(string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetTargets(InitialCatalog);
        }

        public static int GetTargetID(Target target, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetTargetID(target, InitialCatalog);
        }

        public static bool UpdateTarget(Target target, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.UpdateTarget(target, InitialCatalog);
        }

        public static bool RemoveTarget(Target target, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.RemoveTarget(target, InitialCatalog);
        }

        public static bool UpsertTarget(Target target, string InitialCatalog = "Finances")
        {
            if (target.ID == 0)
                return AddTarget(target, InitialCatalog);
            else
                return UpdateTarget(target, InitialCatalog);
        }

        public static bool RemoveAllDataInTargetTable(string InitialCatalog = "Finances")
        {
            return SqlServerCrud.RemoveAllDataInTargetTable(InitialCatalog);
        }

        public static List<Operation> GetIncomeExpenseDataByTarget(Target target, bool isIncome)
        {
            return SqlServerActions.GetIncomeExpenseDataByTarget(target, isIncome);
        }

        #endregion

        #region Currency

        public static bool AddCurrency(Currency currency, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.AddCurrency(currency, InitialCatalog);
        }

        public static bool AddCurrencies(List<Currency> currencies, string InitialCatalog = "Finances")
        {
            foreach (var currency in currencies)
            {
                if (!UpsertCurrency(currency, InitialCatalog)) return false;
            }
            return true;
        }

        public static Currency GetCurrency(int ID, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetCurrency(ID, InitialCatalog);
        }

        public static List<Currency> GetCurrencies(string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetCurrencies(InitialCatalog);
        }

        public static int GetCurrencyID(Currency currency, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.GetCurrencyID(currency, InitialCatalog);
        }

        public static bool UpdateCurrency(Currency currency, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.UpdateCurrency(currency, InitialCatalog);
        }

        public static bool RemoveCurrency(Currency currency, string InitialCatalog = "Finances")
        {
            return SqlServerCrud.RemoveCurrency(currency, InitialCatalog);
        }

        public static bool UpsertCurrency(Currency currency, string InitialCatalog = "Finances")
        {
            if (currency.ID == 0)
                return AddCurrency(currency, InitialCatalog);
            else
                return UpdateCurrency(currency, InitialCatalog);
        }

        public static bool RemoveAllDataInCurrencyTable(string InitialCatalog = "Finances")
        {
            return SqlServerCrud.RemoveAllDataInCurrencyTable(InitialCatalog);
        }

        public static List<Operation> GetIncomeExpenseDataByCurrency(bool isIncome)
        {
            return SqlServerActions.GetIncomeExpenseDataByCurrency(isIncome);
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
