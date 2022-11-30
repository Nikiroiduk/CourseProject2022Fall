using CourseProject2022FallBL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallBL.SqlServer
{
    internal static class SqlServerActions
    {
        private static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "DESKTOP-9922B5A",
            InitialCatalog = "Finances",
            IntegratedSecurity = true,
            Encrypt = false,
        };

        
    }
}
