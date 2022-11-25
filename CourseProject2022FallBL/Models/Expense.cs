﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallBL.Models
{
    public class Expense : INotifyPropertyChanged
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
