using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallWPF.Services
{
    public class FileService
    {
        public void Save(string filename, string data) 
        {
            File.WriteAllText(filename, data);
        }
    }
}
