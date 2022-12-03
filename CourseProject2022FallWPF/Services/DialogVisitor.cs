using CourseProject2022FallBL.Models;
using CourseProject2022FallWPF.View;
using CourseProject2022FallWPF.View.AddEditElements;
using CourseProject2022FallWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Action = CourseProject2022FallBL.Models.Action;

namespace CourseProject2022FallWPF.Services
{
    public class DialogVisitor : IDialogService
    {
        public object DynamicVisit(object data) => Visit((dynamic)data);

        private bool Visit(string res)
        {
            ErrorWindow win = new();
            ErrorWindowViewModel winVm = new(res);
            win.DataContext = winVm;
            return (bool)win.ShowDialog();
        }

        private User Visit(User u)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new (u);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return u;
            return new User();
        }

        private Target Visit(Target t)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new(t);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return t;
            return new Target();
        }

        private Currency Visit(Currency c)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new(c);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return c;
            return new Currency();
        }

        private Operation Visit(Operation o)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new(o);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return o;
            return new Operation();
        }

        private Income Visit(Income i)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new(i);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return i;
            return new Income();
        }

        private Expense Visit(Expense e)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new(e);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return e;
            return new Expense();
        }

        private Action? Visit(Action a)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new(a);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                if (winVm.IsIncome)
                {
                    return new Income() { Operation = winVm.Action.Operation };
                }
                else if (!winVm.IsIncome)
                {
                    return new Expense() { Operation = winVm.Action.Operation };
                }
            return null;
        }
    }
}
