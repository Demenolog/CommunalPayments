using CommunalPayments.Common.DataContext.Sqlite.Models;
using CommunalPayments.Wpf.Infrastructure.Commands;
using CommunalPayments.Wpf.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;
using CommunalPayments.Wpf.Services;

namespace CommunalPayments.Wpf.ViewModels
{
    internal class DataViewWindowViewModel : ViewModel
    {
        #region Свойства

        #region Title : string - Заголовок окна

        private string _title = "Прошлые показания";

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        #endregion Title : string - Заголовок окна

        #region Receipts : ObservableCollection<ReceiptData> - Данные из БД

        private ObservableCollection<ReceiptData> _receipts;

        public ObservableCollection<ReceiptData> Receipts
        {
            get => _receipts;
            set => SetField(ref _receipts, value);
        }

        #endregion Receipts : ObservableCollection<ReceiptData> - Данные из БД

        #region UpdateDataGrid command

        public ICommand UpdateDataGrid { get; }

        private bool CanUpdateDataGridExecuted(object p) => true;

        private void OnUpdateDataGridExecute(object p)
        {
            DatabaseControlService.UpdateDataGrid();
        }

        #endregion UpdateDataGrid command

        #endregion Свойства

        public DataViewWindowViewModel()
        {
            UpdateDataGrid = new LambdaCommand(OnUpdateDataGridExecute, CanUpdateDataGridExecuted);
        }
    }
}