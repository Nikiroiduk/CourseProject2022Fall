using CourseProject2022FallBL.Models;
using CourseProject2022FallWPF.View.AddEditElements;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CourseProject2022FallWPF.ViewModel
{
    public class AddEditWindowViewModel : ViewModel
    {
        public AddEditWindowViewModel(object curObject)
        {
            if (curObject is User user)
            {
                UserName = user.Name;
                UserBlock = new AddEditUserBlock();
            }
            else if (curObject is Target target)
            {
                TargetName = target.Name;
                TargetBlock = new AddEditTargetBlock();
            }
            else if (curObject is Currency currency)
            {
                CurrencyName = currency.Name;
                CurrencyRatio = currency.Ratio;
                TargetBlock = new AddEditCurrencyBlock();
            }
        }

        #region User

        #region UserName
        private string _UserName;

        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }
        #endregion

        #region UserBlock
        private UserControl _UserBlock;

        public UserControl UserBlock
        {
            get => _UserBlock;
            set => Set(ref _UserBlock, value);
        }
        #endregion

        #endregion

        #region Target

        #region TargetName
        private string _TargetName;

        public string TargetName
        {
            get => _TargetName;
            set => Set(ref _TargetName, value);
        }
        #endregion

        #region TargetBlock
        private UserControl _TargetBlock;

        public UserControl TargetBlock
        {
            get => _TargetBlock;
            set => Set(ref _TargetBlock, value);
        }
        #endregion

        #endregion

        #region Currency

        #region CurrencyName
        private string _CurrencyName;

        public string CurrencyName
        {
            get => _CurrencyName.Substring(0, 3).ToUpper();
            set => Set(ref _CurrencyName, value);
        }
        #endregion


        #region CurrencyRatio
        private float _CurrencyRatio;

        public float CurrencyRatio
        {
            get => _CurrencyRatio;
            set => Set(ref _CurrencyRatio, value);
        }
        #endregion

        #region CurrencyBlock
        private UserControl _CurrencyBlock;

        public UserControl CurrencyBlock
        {
            get => _CurrencyBlock;
            set => Set(ref _CurrencyBlock, value);
        }
        #endregion

        private static string getFirstCharacters(string text, int charactersCount)
        {
            int offset = Math.Min(charactersCount, text.Length);
            return text.Substring(0, offset);
        }

        #endregion
    }
}
