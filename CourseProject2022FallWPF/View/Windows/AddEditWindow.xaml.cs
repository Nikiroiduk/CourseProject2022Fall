using System.Windows;

namespace CourseProject2022FallWPF.View
{
    public partial class AddEditWindow : Window
    {
        public AddEditWindow()
        {
            InitializeComponent();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        { 
            DialogResult = true;
            this.Close();
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
