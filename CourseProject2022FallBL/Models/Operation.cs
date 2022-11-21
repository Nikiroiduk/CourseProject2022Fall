using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallBL.Models
{
    public class Operation
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public Currency Currency { get; set; } = new Currency { Name = "Undefined", Ratio = 0 };
        public Target Target { get; set; } = new Target { Name = "Undefined" };
        public User User { get; set; } = new User { Name = "Undefined" };
        public string Comment { get; set; } = "Undefined";
    }
}
