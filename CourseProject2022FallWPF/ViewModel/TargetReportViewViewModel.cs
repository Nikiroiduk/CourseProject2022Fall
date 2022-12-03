using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.Model.Commands;
using CourseProject2022FallWPF.Services;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject2022FallWPF.ViewModel
{
    public class TargetReportViewViewModel : ViewModel
    {
        private FileService fileService;
        private ISaveDialogService dialogService;
        public TargetReportViewViewModel(ISaveDialogService dialogService, FileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            TargetChartLabels = DataService.GetUsers().Select(t => t.Name).ToArray();
            Target = TargetList.FirstOrDefault();
            SaveReport = new LambdaCommand(OnSaveReport, CanSaveReport);
        }

        public string[] TargetChartLabels { get; set; }


        #region Target
        private Target _Target;
        public Target Target
        {
            get => _Target;
            set
            {
                if (Set(ref _Target, value))
                {

                    IncomeTable = new(DataService.GetIncomeExpenseDataByTarget(Target, true));
                    ChartValues<float> income = new();
                    foreach (var item in TargetChartLabels)
                    {
                        income.Add(IncomeTable
                            .Where(i => i.User.Name == item)
                            .Sum(i => i.Value *= i.Currency.Ratio));
                    }

                    ExpenseTable = new(DataService.GetIncomeExpenseDataByTarget(Target, false));
                    ChartValues<float> expense = new();
                    foreach (var item in TargetChartLabels)
                    {
                        expense.Add(ExpenseTable
                            .Where(e => e.User.Name == item)
                            .Sum(e => e.Value *= e.Currency.Ratio));
                    }
                    TargetSeriesCollection = new SeriesCollection
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

                    TargetsPieChart = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Income",
                            Values = new ChartValues<double>
                            {
                                Math.Round(DataService.GetIncomes()
                                           .Where(i => i.Operation.Target.Name == Target.Name)
                                           .Sum(i => i.Operation.Value *= i.Operation.Currency.Ratio), 2)
                            },
                            DataLabels = true,
                        },
                        new PieSeries
                        {
                            Title = "Expense",
                            Values = new ChartValues<double>
                            {
                                Math.Round(DataService.GetExpenses()
                                           .Where(e => e.Operation.Target.Name == Target.Name)
                                           .Sum(e => e.Operation.Value *= e.Operation.Currency.Ratio), 2)
                            },
                            DataLabels = true,
                        }
                    };
                }
            }
        }
        #endregion

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

        #region TargetList
        private List<Target> _TargetList = DataService.GetTargets();
        public List<Target> TargetList
        {
            get => _TargetList;
            set => Set(ref _TargetList, value);
        }
        #endregion

        #region TargetSeriesCollection
        private SeriesCollection _TargetSeriesCollection;
        public SeriesCollection TargetSeriesCollection
        {
            get => _TargetSeriesCollection;
            set => Set(ref _TargetSeriesCollection, value);
        }
        #endregion

        #region TargetsPieChart
        private SeriesCollection _TargetsPieChart;
        public SeriesCollection TargetsPieChart
        {
            get => _TargetsPieChart;
            set => Set(ref _TargetsPieChart, value);
        }
        #endregion

        #region SaveReport
        public ICommand SaveReport { get; }

        private bool CanSaveReport(object p) => true;
        private void OnSaveReport(object p)
        {
            var i = Report(IncomeTable.Where(i => i.Target.Name == Target.Name), name: "Income table");
            var e = Report(ExpenseTable.Where(i => i.Target.Name == Target.Name), name: "Expense table");
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
