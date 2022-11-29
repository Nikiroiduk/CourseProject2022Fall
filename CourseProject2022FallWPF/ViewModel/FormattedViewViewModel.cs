using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Action = CourseProject2022FallBL.Models.Action;

namespace CourseProject2022FallWPF.ViewModel
{
    public class FormattedViewViewModel : ViewModel
    {
        private readonly DialogVisitor Visitor = new();

        public FormattedViewViewModel()
        {
            TypeSelected = new LambdaCommand(OnTypeSelected, CanTypeSelected);
            AddItem = new LambdaCommand(OnAddItem, CanAddItem);
            EditItem = new LambdaCommand(OnEditItem, CanEditItem);
            RemoveItem = new LambdaCommand(OnRemoveItem, CanRemoveItem);
            OnTypeSelected("All");
        }

        #region Items
        private ObservableCollection<Action> _Items = new (DataService.GetActions());
        public ObservableCollection<Action> Items
        {
            get => _Items;
            set => Set(ref _Items, value);
        }
        #endregion

        #region ObservableItems
        private ObservableCollection<Action> _ObservableItems;
        public ObservableCollection<Action> ObservableItems
        {
            get => _ObservableItems;
            set => Set(ref _ObservableItems, value);
        }
        #endregion

        #region IsIncomeSelected
        private bool _IsIncomeSelected = false;
        public bool IsIncomeSelected
        {
            get => _IsIncomeSelected;
            set => Set(ref _IsIncomeSelected, value);
        }
        #endregion

        #region IsExpenseSelected
        private bool _IsExpenseSelected = false;
        public bool IsExpenseSelected
        {
            get => _IsExpenseSelected;
            set => Set(ref _IsExpenseSelected, value);
        }
        #endregion

        #region IsAllSelected
        private bool _IsAllSelected = true;
        public bool IsAllSelected
        {
            get => _IsAllSelected;
            set => Set(ref _IsAllSelected, value);
        }
        #endregion

        #region TypeSelected

        public ICommand TypeSelected { get; }

        private bool CanTypeSelected(object p) => true;
        private void OnTypeSelected(object p)
        {
            if (p is string str){
                switch (str)
                {
                    case "All":
                        ChangeState(true, false, false);
                        ObservableItems = Items;
                        break;
                    case "Income":
                        ChangeState(false, true, false);
                        ObservableItems = new(Items.Where(i => i is Income inc));
                        break;
                    case "Expense":
                        ChangeState(false, false, true);
                        ObservableItems = new(Items.Where(e => e is Expense exp));
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChangeState(bool all, bool income, bool expense)
        {
            IsAllSelected = all;
            IsIncomeSelected = income;
            IsExpenseSelected = expense;
        }

        #endregion

        #region AddItem

        public ICommand AddItem { get; }

        private bool CanAddItem(object p) => true;
        private void OnAddItem(object p)
        {
            
        }

        #endregion

        #region EditItem

        public ICommand EditItem { get; }

        private bool CanEditItem(object p) => true;
        private void OnEditItem(object p)
        {

        }

        #endregion

        #region RemoveItem

        public ICommand RemoveItem { get; }

        private bool CanRemoveItem(object p) => true;
        private void OnRemoveItem(object p)
        {

        }

        #endregion
    }
}
