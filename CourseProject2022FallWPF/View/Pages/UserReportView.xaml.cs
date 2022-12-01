using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserReportView.xaml
    /// </summary>
    public partial class UserReportView : Page
    {
        public UserReportView()
        {
            InitializeComponent();
            Formatter = value => value.ToString("0.00");
            UserGraphAxisY.LabelFormatter = Formatter;
        }

        public Func<double, string> Formatter { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var stream = new FileStream("Templates\\report1.lqd", FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    var templateString = reader.ReadToEnd();
                    var template = dotTemplate.Parse(templateString);
                    var docContext = CreateDocumentContext();
                    var docString = template.Render(docContext);

                    DocViewer.Document = (FlowDocument)XamlReader.Parse(docString);
                }
            }
        }

        private DotLiquid.Hash CreateDocumentContext()
        {
            var context = new
            {
                Title = "Hello, Habrahabr!",
                Subtitle = "Experimenting with dotLiquid, FlowDocument and PDFSharp",
                Steps = new List<dynamic>{
                    new { Title = "Document Context", Description = "Create data source for dotLiquid Template"},
                    new { Title = "Rendering", Description = "Load template string and render it into FlowDocument markup with Document Context given"},
                    new { Title = "Parse markup", Description = "Use XAML Parser to prepare FlowDocument instance"},
                    new { Title = "Save to XPS", Description = "Save prepared FlowDocument into XPS format"},
                    new { Title = "Convert XPS to PDF", Description = "Convert XPS to WPF using PDFSharp"},
                }
            };

            return DotLiquid.Hash.FromAnonymousObject(context);
        }
    }
}
