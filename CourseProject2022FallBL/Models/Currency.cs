using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallBL.Models
{
    public class Currency : INotifyPropertyChanged
    {
        public int ID { get; set; } = 0;
        public float Ratio { 
            get { return _Ratio; }
            set { _Ratio = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; NotifyPropertyChanged(); }
        }

        private string _Name = "UND";
        private float _Ratio = 0.00f;

        public bool isDefault => Name == "UND" || Ratio == 0.00f;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
