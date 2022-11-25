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
            get { return _Value; }
            set { _Value = value; NotifyPropertyChanged(); }
        }
        public string Comment {
            get { return _Comment; }
            set { _Comment = value; NotifyPropertyChanged(); }
        }

        public string _Comment = "Undefined";
        public float _Value = 0f;

        public bool isDefault => _Comment == "Undefined" && _Value == 0f && Currency.isDefault && Target.isDefault && User.isDefault;


        //public event PropertyChangedEventHandler? PropertyChanged
        //{
        //    add
        //    {
        //        ((INotifyPropertyChanged)Currency).PropertyChanged += value;
        //        ((INotifyPropertyChanged)Target).PropertyChanged += value;
        //        ((INotifyPropertyChanged)User).PropertyChanged += value;
        //    }

        //    remove
        //    {
        //        ((INotifyPropertyChanged)Currency).PropertyChanged -= value;
        //        ((INotifyPropertyChanged)Target).PropertyChanged -= value;
        //        ((INotifyPropertyChanged)User).PropertyChanged -= value;
        //    }
        //}

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
