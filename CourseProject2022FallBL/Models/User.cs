using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject2022FallBL.Models
{
    public class User : INotifyPropertyChanged
    {
        public int ID { get; set; } = 0;
        public string Name { 
            get { return _Name; } 
            set { _Name = value; NotifyPropertyChanged(); } 
        }

        private string _Name = "Undefined";
        public bool isDefault => Name == "Undefined";

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
