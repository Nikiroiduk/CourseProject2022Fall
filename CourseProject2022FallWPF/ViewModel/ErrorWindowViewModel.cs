using CourseProject2022FallBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallWPF.ViewModel
{
    public class ErrorWindowViewModel : ViewModel
    {
        public ErrorWindowViewModel(string error)
        {
            ErrorMessage = error;
        }

        #region ErrorMessage
        private string _ErrorMessage = "Error message!";

        public string ErrorMessage
        {
            get => _ErrorMessage;
            set => Set(ref _ErrorMessage, value);
        }
        #endregion
    }
}
