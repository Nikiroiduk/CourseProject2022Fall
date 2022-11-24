using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Model.Enum;
using CourseProject2022FallWPF.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject2022FallWPF.ViewModel
{
    public class RawViewViewModel : ViewModel
    {
        private readonly DialogVisitor Visitor = new();

        public RawViewViewModel()
        {
            Add = new LambdaCommand(OnAdd, CanAdd);
            Edit = new LambdaCommand(OnEdit, CanEdit);
            Remove = new LambdaCommand(OnRemove, CanRemove);
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


        #region Add
        public ICommand Add { get; }

        private bool CanAdd(object p) => true;
        private void OnAdd(object p)
        {
            if (SelectedTab == SelectedTab.User)
            {
                var user = (User)Visitor.DynamicVisit(new User());
                if (user == null || user.Name == "Undefined")
                    return;
                DataService.AddUser(user);
                user.ID = DataService.GetUserID(user);
                UserTable.Add(user);
            }
            else if (SelectedTab == SelectedTab.Target)
            {
                var target = (Target)Visitor.DynamicVisit(new Target());
                if (target == null || target.Name == "Undefined")
                    return;
                DataService.AddTarget(target);
                target.ID = DataService.GetTargetID(target);
                TargetTable.Add(target);
            }
            else if (SelectedTab == SelectedTab.Currency)
            {
                var currency = (Currency)Visitor.DynamicVisit(new Currency());
                if (currency == null || currency.Name == "und" || currency.Ratio == 0)
                    return;
                DataService.AddCurrency(currency);
                currency.ID = DataService.GetCurrencyID(currency);
                CurrencyTable.Add(currency);
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
                if (user == null || user.Name == "Undefined")
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
                if (target == null || target.Name == "Undefined")
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
                if (currency == null || currency.Name == "und")
                    return;
                DataService.UpdateCurrency(currency);
                foreach (var c in CurrencyTable.Where(с => с.ID == currency.ID))
                {
                    c.Name = currency.Name;
                    c.Ratio = currency.Ratio;
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
                DataService.RemoveUser(user);
                UserTable.Remove(user);
            }
            else if (SelectedTab == SelectedTab.Target)
            {
                var target = p as Target;
                DataService.RemoveTarget(target);
                TargetTable.Remove(target);
            }
            else if (SelectedTab == SelectedTab.Currency)
            {
                var currency = p as Currency;
                DataService.RemoveCurrency(currency);
                CurrencyTable.Remove(currency);
            }
        }
        #endregion
    }
}
