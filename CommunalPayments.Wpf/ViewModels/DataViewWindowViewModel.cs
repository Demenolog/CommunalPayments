using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalPayments.Wpf.ViewModels.Base;

namespace CommunalPayments.Wpf.ViewModels
{
    internal class DataViewWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок окна

        private string _title = "Прошлые показания";

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        #endregion Title : string - Заголовок окна
    }
}
