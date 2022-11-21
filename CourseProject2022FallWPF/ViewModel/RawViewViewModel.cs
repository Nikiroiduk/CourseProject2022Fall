using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using CourseProject2022FallWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallWPF.ViewModel
{
    public class RawViewViewModel : ViewModel
    {
        public RawViewViewModel()
        {

        }

        #region IncomeTable
        private List<Income> _IncomeTable = DataService.GetIncomes();
        public List<Income> IncomeTable
        {
            get => _IncomeTable;
            set => Set(ref _IncomeTable, value);
        }
        #endregion
    }
}
