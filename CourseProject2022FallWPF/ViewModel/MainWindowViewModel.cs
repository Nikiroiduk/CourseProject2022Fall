using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject2022FallWPF.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            RawView = new LambdaCommand(OnRawView, CanRawView);
            FormattedView = new LambdaCommand(OnFormattedView, CanFormattedView);
        }

        #region ActivePage
        private Page _ActivePage = new FormattedView();

        public Page ActivePage
        {
            get => _ActivePage;
            set => Set(ref _ActivePage, value);
        }
        #endregion

        #region RawView
        public ICommand RawView { get; }

        private bool CanRawView(object p) => true;
        private void OnRawView(object p)
        {
            ActivePage = new RawView();
        }
        #endregion

        #region FormattedView
        public ICommand FormattedView { get; }

        private bool CanFormattedView(object p) => true;
        private void OnFormattedView(object p)
        {
            ActivePage = new FormattedView();
        }
        #endregion

    }
}
