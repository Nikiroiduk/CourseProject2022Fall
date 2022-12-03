
using System.ComponentModel;

namespace CourseProject2022FallBL.Models
{
    public class Income : Action, INotifyPropertyChanged
    {
        public int ID { get; set; }
        public Operation Operation { get; set; } = new Operation();

        public bool isDefault => Operation.isDefault;
        public bool isIncome => true;

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

        public override string ToString()
        {
            return $"{ID},{Operation.ID}," +
                $"{Operation.Value}," +
                $"{Operation.Comment.Replace(",", "")}," +
                $"{Operation.Currency.ID}," +
                $"{Operation.Currency.Name}," +
                $"{Operation.Currency.Ratio}," +
                $"{Operation.Target.ID}," +
                $"{Operation.Target.Name}," +
                $"{Operation.User.ID}," +
                $"{Operation.User.Name}\n";
        }
    }
}
