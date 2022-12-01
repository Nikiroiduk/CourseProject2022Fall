using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CourseProject2022FallWPF.ViewModel
{
    internal class UserReportVIewViewModel : ViewModel
    {
        public UserReportVIewViewModel()
        {
            UserChartLabels = DataService.GetTargets().Select(t => t.Name).ToArray();
            User = UserList.FirstOrDefault();
        }
        public string[] UserChartLabels { get; set; }


        #region User
        private User _User;
        public User User
        {
            get => _User;
            set
            {
                if (Set(ref _User, value))
                {

                    IncomeTable = new(DataService.GetIncomeExpenseDataByUser(User, true));
                    ChartValues<float> income = new();
                    foreach (var item in UserChartLabels)
                    {
                        income.Add(IncomeTable
                            .Where(i => i.Target.Name == item)
                            .Sum(i => i.Value *= i.Currency.Ratio));
                    }

                    ExpenseTable = new(DataService.GetIncomeExpenseDataByUser(User, false));
                    ChartValues<float> expense = new();
                    foreach (var item in UserChartLabels)
                    {
                        expense.Add(ExpenseTable
                            .Where(e => e.Target.Name == item)
                            .Sum(e => e.Value *= e.Currency.Ratio));
                    }
                    UserSeriesCollection = new SeriesCollection
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

                    UsersPieChart = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Income",
                            Values = new ChartValues<double>
                            {
                                Math.Round(DataService.GetIncomes()
                                           .Where(i => i.Operation.User.Name == User.Name)
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
                                           .Where(e => e.Operation.User.Name == User.Name)
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

        #region UserList
        private List<User> _UserList = DataService.GetUsers();
        public List<User> UserList
        {
            get => _UserList;
            set => Set(ref _UserList, value);
        }
        #endregion

        #region UserSeriesCollection
        private SeriesCollection _UserSeriesCollection;
        public SeriesCollection UserSeriesCollection
        {
            get => _UserSeriesCollection;
            set => Set(ref _UserSeriesCollection, value);
        }
        #endregion

        #region UsersPieChart
        private SeriesCollection _UsersPieChart;
        public SeriesCollection UsersPieChart
        {
            get => _UsersPieChart;
            set => Set(ref _UsersPieChart, value);
        }
        #endregion

    }
}
