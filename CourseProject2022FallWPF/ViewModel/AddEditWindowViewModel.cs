using CourseProject2022FallBL.Models;
using CourseProject2022FallWPF.View.AddEditElements;
using System.Windows.Controls;

namespace CourseProject2022FallWPF.ViewModel
{
    public class AddEditWindowViewModel : ViewModel
    {
        public AddEditWindowViewModel(object curObject)
        {
            if (curObject is User user)
            {
                UserName = user.Name;
                ActivePage = new AddEditUserBlock();
            }
            //else if (curObject is Income income)
            //{
            //    ActivePage = new AddEditIncomeBlock();
            //}
        }

        #region UserName
        private string _UserName;

        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }
        #endregion

        #region ActivePage
        private Page _ActivePage;

        public Page ActivePage
        {
            get => _ActivePage;
            set => Set(ref _ActivePage, value);
        }
        #endregion
    }
}
