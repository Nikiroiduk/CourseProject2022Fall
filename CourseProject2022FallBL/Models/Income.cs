
using System.ComponentModel;

namespace CourseProject2022FallBL.Models
{
    public class Income : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public Operation Operation { get; set; } = new Operation();

        public bool isDefault => Operation.isDefault;

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)Operation).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)Operation).PropertyChanged -= value;
            }
        }
    }
}
