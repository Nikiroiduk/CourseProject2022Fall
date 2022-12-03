using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject2022FallBL.Models
{
    public class Operation : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public Currency Currency { get; set; } = new ();
        public Target Target { get; set; } = new ();
        public User User { get; set; } = new ();
        public float Value {
            get { return LimitDecimalPlace(_Value, 2); }
            set { _Value = value; NotifyPropertyChanged(); }
        }
        public string Comment {
            get { return _Comment; }
            set { _Comment = value; NotifyPropertyChanged(); }
        }

        public string _Comment = "Undefined";
        public float _Value = 0f;

        public bool isDefault => _Comment == "Undefined" || _Value == 0f || Currency.isDefault || Target.isDefault || User.isDefault;

        private float LimitDecimalPlace(double number, int limitPlace)
        {
            string sNumber = number.ToString();
            int decimalIndex = sNumber.IndexOf(".");
            if (decimalIndex != -1 && sNumber.Length - decimalIndex >= 2)
            {
                sNumber = sNumber.Remove(decimalIndex + limitPlace + 1);
            }

            var result = float.Parse(sNumber);
            return result;
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return $"{ID}," +
                $"{Value}," +
                $"{Comment.Replace(",", "")}," +
                $"{Currency.ID}," +
                $"{Currency.Name}," +
                $"{Currency.Ratio}," +
                $"{Target.ID}," +
                $"{Target.Name}," +
                $"{User.ID}," +
                $"{User.Name}\n";
        }

    }
}
