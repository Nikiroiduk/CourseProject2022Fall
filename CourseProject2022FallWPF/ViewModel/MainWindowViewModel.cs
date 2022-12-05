using CourseProject2022FallBL.Models;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Services;
using CourseProject2022FallWPF.View;
using CourseProject2022FallWPF.View.Pages;
using System;
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
            UserReport = new LambdaCommand(OnUserReport, CanUserReport);
            TargetReport = new LambdaCommand(OnTargetReport, CanTargetReport);
            CurrencyReport = new LambdaCommand(OnCurrencyReport, CanCurrencyReport);
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

        #region UserReport
        public ICommand UserReport { get; }

        private bool CanUserReport(object p) => true;
        private void OnUserReport(object p)
        {
            ActivePage = new UserReportView();
        }
        #endregion

        #region TargetReport
        public ICommand TargetReport { get; }

        private bool CanTargetReport(object p) => true;
        private void OnTargetReport(object p)
        {
            ActivePage = new TargetReportView();
        }
        #endregion

        #region CurrencyReport
        public ICommand CurrencyReport { get; }

        private bool CanCurrencyReport(object p) => true;
        private void OnCurrencyReport(object p)
        {
            ActivePage = new CurrencyReportView();
        }
        #endregion

    }
}
