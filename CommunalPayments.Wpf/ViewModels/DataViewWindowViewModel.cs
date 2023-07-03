using CommunalPayments.Common.DataContext.Sqlite.Models;
using CommunalPayments.Wpf.Infrastructure.Commands;
using CommunalPayments.Wpf.Services;
using CommunalPayments.Wpf.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        #region DeleteNumber : string - Номер строки для удаления

        private string _deleteNumber;

        public string DeleteNumber
        {
            get => _deleteNumber;
            set
            {
                if (TextBoxValidationService.IsIntNumber(value))
                {
                    SetField(ref _deleteNumber, value);
                }
            }
        }

        #endregion DeleteNumber : string - Номер строки для удаления

        #region Receipts : ObservableCollection<ReceiptData> - Данные из БД для dataGrid

        private ObservableCollection<ReceiptData> _receipts;

        public ObservableCollection<ReceiptData> Receipts
        {
            get => _receipts;
            set => SetField(ref _receipts, value);
        }

        #endregion Receipts : ObservableCollection<ReceiptData> - Данные из БД для dataGrid

        #endregion Свойства

        #region Команды

        #region UpdateDataGrid command

        public ICommand UpdateDataGrid { get; }

        private bool CanUpdateDataGridExecuted(object p) => true;

        private void OnUpdateDataGridExecute(object p)
        {
            DatabaseControlService.UpdateDataGrid();
        }

        #endregion UpdateDataGrid command

        #region DeleteData command

        public ICommand DeleteData { get; }

        private bool CanDeleteDataExecuted(object p) => true;

        private void OnDeleteDataExecute(object p)
        {
            var deleteNumber = int.Parse(DeleteNumber);

            DatabaseControlService.DeleteData(deleteNumber);
        }

        #endregion DeleteData command

        #endregion Команды

        public DataViewWindowViewModel()
        {
            UpdateDataGrid = new LambdaCommand(OnUpdateDataGridExecute, CanUpdateDataGridExecuted);

            DeleteData = new LambdaCommand(OnDeleteDataExecute, CanDeleteDataExecuted);
        }
    }
}