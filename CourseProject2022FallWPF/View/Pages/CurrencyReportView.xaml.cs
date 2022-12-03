using CourseProject2022FallWPF.Services;
using CourseProject2022FallWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject2022FallWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for CurrencyReportView.xaml
    /// </summary>
    public partial class CurrencyReportView : Page
    {
        public CurrencyReportView()
        {
            InitializeComponent();
            Formatter = value => value.ToString("0.00");
            CurrencyGraphAxisY.LabelFormatter = Formatter;
            DataContext = new CurrencyReportViewViewModel(new DefaultSaveDialogService(), new FileService());
        }

        public Func<double, string> Formatter { get; set; }

    }
}
