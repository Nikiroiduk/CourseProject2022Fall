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
