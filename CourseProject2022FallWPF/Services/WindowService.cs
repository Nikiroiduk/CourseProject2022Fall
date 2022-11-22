using CourseProject2022FallWPF.View;
using CourseProject2022FallWPF.ViewModel;
using System.Windows.Controls;

namespace CourseProject2022FallWPF.Services
{
    public class WindowService : IWindowService
    {
        public void CreateWindow(object CurrentPage)
        {
            AddEditWindow win = new();
            var CurPage = CurrentPage as Page;
            AddEditWindowViewModel winVm = new(CurPage);
            win.DataContext = winVm;
            win.Show();
        }
    }
}
