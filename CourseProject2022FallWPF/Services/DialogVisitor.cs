using CourseProject2022FallBL.Models;
using CourseProject2022FallWPF.View;
using CourseProject2022FallWPF.View.AddEditElements;
using CourseProject2022FallWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallWPF.Services
{
    public class DialogVisitor : IDialogService
    {
        public object DynamicVisit(object data) => Visit((dynamic)data);

        private User Visit(User u)
        {
            AddEditWindow win = new();
            AddEditWindowViewModel winVm = new (u);
            win.DataContext = winVm;
            if ((bool)win.ShowDialog())
                return u;
            return null;
        }
    }
}
