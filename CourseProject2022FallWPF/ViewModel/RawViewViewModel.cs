using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Model.Enum;
using CourseProject2022FallWPF.Services;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CourseProject2022FallWPF.ViewModel
{
    public class RawViewViewModel : ViewModel
    {
        private readonly DialogVisitor Visitor = new();

        private static string DeleteErrorMessage(string name) => $"An error occurred when deleting a {name}";
        private static string EditErrorMessage(string name) => $"An error occurred when editing a {name}";

        public RawViewViewModel()
        {
            Add = new LambdaCommand(OnAdd, CanAdd);
            Edit = new LambdaCommand(OnEdit, CanEdit);
            Remove = new LambdaCommand(OnRemove, CanRemove);
            Reload = new LambdaCommand(OnReload, CanReload);
        }

        #region Collections

        #region IncomeTable
        private ObservableCollection<Income> _IncomeTable = new(DataService.GetIncomes());
        public ObservableCollection<Income> IncomeTable
        {
            get => _IncomeTable;
            set => Set(ref _IncomeTable, value);
        }
        #endregion

        #region ExpenseTable
        private ObservableCollection<Expense> _ExpenseTable = new(DataService.GetExpenses());
        public ObservableCollection<Expense> ExpenseTable
        {
            get => _ExpenseTable;
            set => Set(ref _ExpenseTable, value);
        }
        #endregion


        #region OperationTable
        private ObservableCollection<Operation> _OperationTable = new(DataService.GetOperations());
        public ObservableCollection<Operation> OperationTable
        {
            get => _OperationTable;
            set => Set(ref _OperationTable, value);
        }
        #endregion

        #region UserTable
        private ObservableCollection<User> _UserTable = new(DataService.GetUsers());
        public ObservableCollection<User> UserTable
        {
            get => _UserTable;
            set => Set(ref _UserTable, value);
        }
        #endregion

        #region TargetTable
        private ObservableCollection<Target> _TargetTable = new(DataService.GetTargets());
        public ObservableCollection<Target> TargetTable
        {
            get => _TargetTable;
            set => Set(ref _TargetTable, value);
        }
        #endregion

        #region CurrencyTable
        private ObservableCollection<Currency> _CurrencyTable = new(DataService.GetCurrencies());
        public ObservableCollection<Currency> CurrencyTable
        {
            get => _CurrencyTable;
            set => Set(ref _CurrencyTable, value);
        }
        #endregion

        #endregion

        #region SelectedTab
        private SelectedTab _SelectedTab = SelectedTab.Income;
        public SelectedTab SelectedTab
        {
            get => _SelectedTab;
            set => Set(ref _SelectedTab, value);
        }
        #endregion

        #region Reload

        public ICommand Reload { get; }

        private bool CanReload(object p) => true;
        private void OnReload(object p)
        {
            UserTable = new(DataService.GetUsers());
            TargetTable = new(DataService.GetTargets());
            CurrencyTable = new(DataService.GetCurrencies());
            OperationTable = new(DataService.GetOperations());
            IncomeTable = new(DataService.GetIncomes());
            ExpenseTable = new(DataService.GetExpenses());
        }

        #endregion


        #region Add
        public ICommand Add { get; }

        private bool CanAdd(object p) => true;
        private void OnAdd(object p)
        {
            if (SelectedTab == SelectedTab.User)
            {
                var user = (User)Visitor.DynamicVisit(new User());
                if (user.isDefault || user == null)
                    return;
                DataService.UpsertUser(user);
                user.ID = DataService.GetUserID(user);
                if (UserTable.Where(u => u.ID == user.ID).IsNullOrEmpty())
                    UserTable.Add(user);
                else
                    foreach (var u in UserTable.Where(u => u.ID == user.ID))
                    {
                        u.Name = user.Name;
                    }
            }
            else if (SelectedTab == SelectedTab.Target)
            {
                var target = (Target)Visitor.DynamicVisit(new Target());
                if (target.isDefault || target == null)
                    return;
                DataService.UpsertTarget(target);
                target.ID = DataService.GetTargetID(target);
                if (TargetTable.Where(t => t.ID == target.ID).IsNullOrEmpty())
                    TargetTable.Add(target);
                else
                    foreach (var t in TargetTable.Where(t => t.ID == target.ID))
                    {
                        t.Name = target.Name;
                    }
            }
            else if (SelectedTab == SelectedTab.Currency)
            {
                var currency = (Currency)Visitor.DynamicVisit(new Currency());
                if (currency.isDefault || currency == null)
                    return;
                DataService.UpsertCurrency(currency);
                currency.ID = DataService.GetCurrencyID(currency);
                if (CurrencyTable.Where(c => c.ID == currency.ID).IsNullOrEmpty())
                    CurrencyTable.Add(currency);
                else
                    foreach (var c in CurrencyTable.Where(c => c.ID == currency.ID))
                    {
                        c.Name = currency.Name;
                        c.Ratio = currency.Ratio;
                    }
            }
            else if (SelectedTab == SelectedTab.Operation)
            {
                var operation = (Operation)Visitor.DynamicVisit(new Operation());
                if (operation.isDefault || operation == null)
                    return;

                DataService.UpsertOperation(operation);
                operation.User.ID = DataService.GetUserID(operation.User);
                operation.Target.ID = DataService.GetTargetID(operation.Target);
                operation.Currency.ID = DataService.GetCurrencyID(operation.Currency);
                operation.ID = DataService.GetOperationID(operation);
                if (OperationTable.Where(o => o.ID == operation.ID).IsNullOrEmpty())
                    OperationTable.Add(operation);
                else
                    foreach (var o in OperationTable.Where(o => o.ID == operation.ID))
                    {
                        o.Value = operation.Value;
                        o.Comment = operation.Comment;
                        o.Target = operation.Target;
                        o.User = operation.User;
                        o.Currency = operation.Currency;
                    }
            }
            else if (SelectedTab == SelectedTab.Income)
            {
                var income = (Income)Visitor.DynamicVisit(new Income());
                if (income.isDefault || income == null)
                    return;

                DataService.UpsertOperation(income.Operation);
                income.Operation.User.ID = DataService.GetUserID(income.Operation.User);
                income.Operation.Target.ID = DataService.GetTargetID(income.Operation.Target);
                income.Operation.Currency.ID = DataService.GetCurrencyID(income.Operation.Currency);
                income.Operation.ID = DataService.GetOperationID(income.Operation);
                DataService.UpsertIncome(income);
                income.ID = DataService.GetIncomeID(income);
                if (IncomeTable.Where(i => i.ID == income.ID).IsNullOrEmpty())
                    IncomeTable.Add(income);
                else
                    foreach (var i in IncomeTable.Where(i => i.ID == income.ID))
                    {
                        i.Operation.Value = income.Operation.Value;
                        i.Operation.Comment = income.Operation.Comment;
                        i.Operation.Target = income.Operation.Target;
                        i.Operation.User = income.Operation.User;
                        i.Operation.Currency = income.Operation.Currency;
                    }
            }
            else if (SelectedTab == SelectedTab.Expense)
            {
                var expense = (Expense)Visitor.DynamicVisit(new Expense());
                if (expense.isDefault || expense == null)
                    return;

                DataService.UpsertOperation(expense.Operation);
                expense.Operation.User.ID = DataService.GetUserID(expense.Operation.User);
                expense.Operation.Target.ID = DataService.GetTargetID(expense.Operation.Target);
                expense.Operation.Currency.ID = DataService.GetCurrencyID(expense.Operation.Currency);
                expense.Operation.ID = DataService.GetOperationID(expense.Operation);
                DataService.UpsertExpense(expense);
                expense.ID = DataService.GetExpenseID(expense);
                if (ExpenseTable.Where(e => e.ID == expense.ID).IsNullOrEmpty())
                    ExpenseTable.Add(expense);
                else
                    foreach (var e in ExpenseTable.Where(e => e.ID == expense.ID))
                    {
                        e.Operation.Value = expense.Operation.Value;
                        e.Operation.Comment = expense.Operation.Comment;
                        e.Operation.Target = expense.Operation.Target;
                        e.Operation.User = expense.Operation.User;
                        e.Operation.Currency = expense.Operation.Currency;
                    }
            }
        }
        #endregion

        #region Edit
        public ICommand Edit { get; }

        private bool CanEdit(object p) => true;
        private void OnEdit(object p)
        {
            if (SelectedTab == SelectedTab.User)
            {
                var user = p as User;
                user = (User)Visitor.DynamicVisit(user);
                if (user.isDefault)
                    return;
                DataService.UpdateUser(user);
                foreach (var u in UserTable.Where(u => u.ID == user.ID))
                {
                    u.Name = user.Name;
                }
            }
            else if (SelectedTab == SelectedTab.Target)
            {
                var target = p as Target;
                target = (Target)Visitor.DynamicVisit(target);
                if (target.isDefault)
                    return;
                DataService.UpdateTarget(target);
                foreach (var t in TargetTable.Where(t => t.ID == target.ID))
                {
                    t.Name = target.Name;
                }
            }
            else if (SelectedTab == SelectedTab.Currency)
            {
                var currency = p as Currency;
                currency = (Currency)Visitor.DynamicVisit(currency);
                if (currency.isDefault)
                    return;
                DataService.UpdateCurrency(currency);
                foreach (var c in CurrencyTable.Where(с => с.ID == currency.ID))
                {
                    c.Name = currency.Name;
                    c.Ratio = currency.Ratio;
                }
            }
            else if (SelectedTab == SelectedTab.Operation)
            {
                var operation = p as Operation;
                operation = (Operation)Visitor.DynamicVisit(operation);
                if (operation.isDefault)
                    return;
                DataService.UpdateOperation(operation);
                foreach (var o in OperationTable.Where(o => o.ID == operation.ID))
                {
                    o.Value = operation.Value;
                    o.Comment = operation.Comment;
                    o.Target = operation.Target;
                    o.User = operation.User;
                    o.Currency = operation.Currency;
                }
            }
            else if (SelectedTab == SelectedTab.Income)
            {
                var income = p as Income;
                income = (Income)Visitor.DynamicVisit(income);
                if (income.isDefault)
                    return;
                DataService.UpdateIncome(income);
                foreach (var i in IncomeTable.Where(i => i.ID == income.ID))
                {
                    i.Operation.Value = income.Operation.Value;
                    i.Operation.Comment = income.Operation.Comment;
                    i.Operation.Target = income.Operation.Target;
                    i.Operation.User = income.Operation.User;
                    i.Operation.Currency = income.Operation.Currency;
                }
            }
            else if (SelectedTab == SelectedTab.Expense)
            {
                var expense = p as Expense;
                expense = (Expense)Visitor.DynamicVisit(expense);
                if (expense.isDefault)
                    return;
                DataService.UpdateExpense(expense);
                foreach (var e in ExpenseTable.Where(e => e.ID == expense.ID))
                {
                    e.Operation.Value = expense.Operation.Value;
                    e.Operation.Comment = expense.Operation.Comment;
                    e.Operation.Target = expense.Operation.Target;
                    e.Operation.User = expense.Operation.User;
                    e.Operation.Currency = expense.Operation.Currency;
                }
            }
        }
        #endregion

        #region Remove
        public ICommand Remove { get; }

        private bool CanRemove(object p) => true;
        private void OnRemove(object p)
        {
            if (SelectedTab == SelectedTab.User)
            {
                var user = p as User;
                if (DataService.RemoveUser(user))
                    UserTable.Remove(user);
                else
                    Visitor.DynamicVisit(DeleteErrorMessage("user"));
            }
            else if (SelectedTab == SelectedTab.Target)
            {
                var target = p as Target;
                if (DataService.RemoveTarget(target))
                    TargetTable.Remove(target);
                else
                    Visitor.DynamicVisit(DeleteErrorMessage("target"));
            }
            else if (SelectedTab == SelectedTab.Currency)
            {
                var currency = p as Currency;
                if (DataService.RemoveCurrency(currency))
                    CurrencyTable.Remove(currency);
                else    
                    Visitor.DynamicVisit(DeleteErrorMessage("currency"));
            }
            else if (SelectedTab == SelectedTab.Operation)
            {
                var operation = p as Operation;
                if (DataService.RemoveOperation(operation))
                    OperationTable.Remove(operation);
                else
                    Visitor.DynamicVisit(DeleteErrorMessage("operation"));
            }
            else if (SelectedTab == SelectedTab.Income)
            {
                var income = p as Income;
                if (DataService.RemoveIncome(income))
                    IncomeTable.Remove(income);
                else
                    Visitor.DynamicVisit(DeleteErrorMessage("income"));
            }
            else if (SelectedTab == SelectedTab.Expense)
            {
                var expense = p as Expense;
                if (DataService.RemoveExpense(expense))
                    ExpenseTable.Remove(expense);
                else
                    Visitor.DynamicVisit(DeleteErrorMessage("expense"));
            }
        }
        #endregion
    }
}
