using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject2022FallWPF.ViewModel
{
    internal class CurrencyReportViewViewModel : ViewModel
    {
        private FileService fileService;
        private ISaveDialogService dialogService;
        public CurrencyReportViewViewModel(ISaveDialogService dialogService, FileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            CurrencyChartLabels = DataService.GetCurrencies().Select(c => c.Name).ToArray();
            SaveReport = new LambdaCommand(OnSaveReport, CanSaveReport);

            IncomeTable = new(DataService.GetIncomeExpenseDataByCurrency(true));
            ChartValues<float> income = new();
            foreach (var item in CurrencyChartLabels)
            {
                income.Add(IncomeTable
                    .Where(i => i.Currency.Name == item)
                    .Sum(i => i.Value));
            }

            ExpenseTable = new(DataService.GetIncomeExpenseDataByCurrency(false));
            ChartValues<float> expense = new();
            foreach (var item in CurrencyChartLabels)
            {
                expense.Add(ExpenseTable
                    .Where(e => e.Currency.Name == item)
                    .Sum(e => e.Value));
            }
            CurrencySeriesCollection = new SeriesCollection
                    {
                        new StackedColumnSeries
                        {
                            Values = income,
                            StackMode = StackMode.Values,
                            DataLabels = true,
                            Title = "Income",
                        },
                        new StackedColumnSeries
                        {
                            Values = expense,
                            StackMode = StackMode.Values,
                            DataLabels = true,
                            Title = "Expense",
                        },

                    };
        }

        public string[] CurrencyChartLabels { get; set; }

        #region IncomeTable
        private ObservableCollection<Operation> _IncomeTable;
        public ObservableCollection<Operation> IncomeTable
        {
            get => _IncomeTable;
            set => Set(ref _IncomeTable, value);
        }
        #endregion

        #region ExpenseTable
        private ObservableCollection<Operation> _ExpenseTable;
        public ObservableCollection<Operation> ExpenseTable
        {
            get => _ExpenseTable;
            set => Set(ref _ExpenseTable, value);
        }
        #endregion

        #region CurrencySeriesCollection
        private SeriesCollection _CurrencySeriesCollection;
        public SeriesCollection CurrencySeriesCollection
        {
            get => _CurrencySeriesCollection;
            set => Set(ref _CurrencySeriesCollection, value);
        }
        #endregion

        #region SaveReport
        public ICommand SaveReport { get; }

        private bool CanSaveReport(object p) => true;
        private void OnSaveReport(object p)
        {
            var i = Report(IncomeTable, name: "Income table");
            var e = Report(ExpenseTable, name: "Expense table");
            try
            {
                if (dialogService.SaveFileDialog() == true)
                {
                    fileService.Save(dialogService.FilePath, i + e);
                    dialogService.ShowMessage("File saved");
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }

        private string Report(IEnumerable<Operation> operations, string name = "tableName")
        {
            var res = $"{name}\n" +
                      "ID,Value,Comment,CurrencyID," +
                      "CurrencyName,CurrencyRatio,TargetID," +
                      "TargetName,UserID,UserName\n";

            foreach (var item in operations)
            {
                res += item.ToString();
            }

            return res;
        }
        #endregion

    }
}
