using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.View.AddEditElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace CourseProject2022FallWPF.ViewModel
{
    public class AddEditWindowViewModel : ViewModel
    {
        public AddEditWindowViewModel(object curObject)
        {
            if (curObject is User user)
            {
                User = user;
                UserBlock = new AddEditUserBlock();
            }
            else if (curObject is Target target)
            {
                Target = target;
                TargetBlock = new AddEditTargetBlock();
            }
            else if (curObject is Currency currency)
            {
                Currency = currency;
                CurrencyBlock = new AddEditCurrencyBlock();
            }
            else if (curObject is Operation operation)
            {
                Operation = operation;
                User = operation.User;
                Target = operation.Target;
                Currency = operation.Currency;
                OperationBlock = new AddEditOperationBlock();
            }
            else if (curObject is Income income)
            {
                Income = income;
                Operation = income.Operation;
                User = income.Operation.User;
                Target = income.Operation.Target;
                Currency = income.Operation.Currency;
                IncomeBlock = new AddEditIncomeBlock();
            }
            else if (curObject is Expense expense)
            {
                Expense = expense;
                Operation = expense.Operation;
                User = expense.Operation.User;
                Target = expense.Operation.Target;
                Currency = expense.Operation.Currency;
                ExpenseBlock = new AddEditIncomeBlock();
            }
        }

        #region User

        #region User
        private User _User;

        public User User
        {
            get => _User;
            set => Set(ref _User, value);
        }
        #endregion

        #region UsersList
        private List<User> _UsersList = DataService.GetUsers();

        public List<User> UsersList
        {
            get => _UsersList;
            set => Set(ref _UsersList, value);
        }
        #endregion

        #region UserBlock
        private UserControl _UserBlock;

        public UserControl UserBlock
        {
            get => _UserBlock;
            set => Set(ref _UserBlock, value);
        }
        #endregion

        #endregion

        #region Target

        #region Target
        private Target _Target;

        public Target Target
        {
            get => _Target;
            set => Set(ref _Target, value);
        }
        #endregion

        #region TargetsList
        private List<Target> _TargetsList = DataService.GetTargets();

        public List<Target> TargetsList
        {
            get => _TargetsList;
            set => Set(ref _TargetsList, value);
        }
        #endregion

        #region TargetBlock
        private UserControl _TargetBlock;

        public UserControl TargetBlock
        {
            get => _TargetBlock;
            set => Set(ref _TargetBlock, value);
        }
        #endregion

        #endregion

        #region Currency

        #region Currency
        private Currency _Currency;

        public Currency Currency
        {
            get => _Currency;
            set => Set(ref _Currency, value);
        }
        #endregion

        #region CurrenciesList
        private List<Currency> _CurrenciesList = DataService.GetCurrencies();

        public List<Currency> CurrenciesList
        {
            get => _CurrenciesList;
            set => Set(ref _CurrenciesList, value);
        }
        #endregion

        #region CurrencyBlock
        private UserControl _CurrencyBlock;

        public UserControl CurrencyBlock
        {
            get => _CurrencyBlock;
            set => Set(ref _CurrencyBlock, value);
        }
        #endregion

        #endregion

        #region Operation

        #region Operation
        private Operation _Operation;

        public Operation Operation
        {
            get => _Operation;
            set => Set(ref _Operation, value);
        }
        #endregion

        #region OperationBlock
        private UserControl _OperationBlock;

        public UserControl OperationBlock
        {
            get => _OperationBlock;
            set => Set(ref _OperationBlock, value);
        }
        #endregion

        #endregion

        #region Income

        #region Income
        private Income _Income;

        public Income Income
        {
            get => _Income;
            set => Set(ref _Income, value);
        }
        #endregion

        #region IncomeBlock
        private UserControl _IncomeBlock;

        public UserControl IncomeBlock
        {
            get => _IncomeBlock;
            set => Set(ref _IncomeBlock, value);
        }
        #endregion

        #endregion

        #region Expense

        #region Expense
        private Expense _Expense;

        public Expense Expense
        {
            get => _Expense;
            set => Set(ref _Expense, value);
        }
        #endregion

        #region ExpenseBlock
        private UserControl _ExpenseBlock;

        public UserControl ExpenseBlock
        {
            get => _ExpenseBlock;
            set => Set(ref _ExpenseBlock, value);
        }
        #endregion

        #endregion
    }
}
