using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Services;
using CourseProject2022FallWPF.View;
using CourseProject2022FallWPF.View.AddEditElements;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        #region IncomeTable
        private List<Income> _IncomeTable = DataService.GetIncomes();
        public List<Income> IncomeTable
        {
            get => _IncomeTable;
            set => Set(ref _IncomeTable, value);
        }
        #endregion

        #region UserTable
        private List<User> _UserTable = DataService.GetUsers();
        public List<User> UserTable
        {
            get => _UserTable;
            set => Set(ref _UserTable, value);
        }
        #endregion

        #region Add
        public ICommand Add { get; }

        private bool CanAdd(object p) => true;
        private void OnAdd(object p)
        {
            if (p is User user)
            {
                User newUser = new();
                newUser = Visitor.DynamicVisit(newUser) as User;
                if (newUser == null || newUser.Name.IsNullOrEmpty())
                    return;
                UserTable.Add(newUser);
                DataService.AddUser(newUser);
                //OpenAddEditWindow(new AddEditUserBlock());
            }
        }
        #endregion

        #region Edit
        public ICommand Edit { get; }

        private bool CanEdit(object p) => true;
        private void OnEdit(object p)
        {
            if (p is User user)
            {
                user = Visitor.DynamicVisit(user) as User;
                if (user == null || user.Name.IsNullOrEmpty())
                    return;
                //UserTable.Add(user);
                //DataService.AddUser(user);
                //OpenAddEditWindow(new AddEditUserBlock());
            }
        }
        #endregion


        private void OpenAddEditWindow(Page page)
        {
            WindowService windowService = new();
            windowService.CreateWindow(page);
        }
    }
}
