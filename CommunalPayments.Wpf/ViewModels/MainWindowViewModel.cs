using CommunalPayments.Wpf.ViewModels.Base;

namespace CommunalPayments.Wpf.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Главное окно

        #region Свойства

        #region Title : string - заголовок главного окна

        private string _title = "Калькулятор ЖКХ платежей";

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        #endregion Title : string - заголовок главного окна

        #endregion Свойства

        #endregion Главное окно
    }
}