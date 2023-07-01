﻿using CommunalPayments.Wpf.ViewModels.Base;

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

        #region Блок - Общая информация

        #region Свойства

        #region CalculationYear : string - Выбранный год для расчёта

        private string _calculationYear;

        public string CalculationYear
        {
            get => _calculationYear;
            set => SetField(ref _calculationYear, value);
        }

        #endregion CalculationYear : string - Выбранный год для расчёта

        #region CalculationMonth : string - Выбранный месяц для расчёта

        private string _calculationMonth;

        public string CalculationMonth
        {
            get => _calculationMonth;
            set => SetField(ref _calculationMonth, value);
        }

        #endregion CalculationMonth : string - Выбранный месяц для расчёта

        #region NumberResidents : string - Количество проживающих на момент расчёта

        private string _numberResidents;

        public string NumberResidents
        {
            get => _numberResidents;
            set => SetField(ref _numberResidents, value);
        }

        #endregion NumberResidents : string - Количество проживающих на момент расчёта

        #endregion Свойства

        #endregion Блок - Общая информация

        #region Блок - Показания приборов

        #region Подблок - Холодное водоснабжение

        #region IsMeteringDevicesColdSelected : bool - Состояние чекбокса приборов для ХВС

        private bool _isMeteringDevicesColdSelected = true;

        public bool IsMeteringDevicesColdSelected
        {
            get => _isMeteringDevicesColdSelected;
            set
            {
                SetField(ref _isMeteringDevicesColdSelected, value);
                SetField(ref _isStandardVolumeColdSelected, !_isMeteringDevicesColdSelected);
                OnPropertyChanged(nameof(IsStandardVolumeColdSelected));
            }
        }

        #endregion IsMeteringDevicesColdSelected : bool - Состояние чекбокса приборов для ХВС

        #region IsStandardVolumeColdSelected : bool - Состояние чекбокса нормативного объёма для ХВС

        private bool _isStandardVolumeColdSelected;

        public bool IsStandardVolumeColdSelected
        {
            get => _isStandardVolumeColdSelected;
            set
            {
                SetField(ref _isStandardVolumeColdSelected, value);
                SetField(ref _isMeteringDevicesColdSelected, !_isStandardVolumeColdSelected);
                OnPropertyChanged(nameof(IsMeteringDevicesColdSelected));
            }
        }

        #endregion IsStandardVolumeColdSelected : bool - Состояние чекбокса нормативного объёма для ХВС

        #region InstrumentCurrentValueCold : string - Текущие значения счётчика для ХВС

        private string _instrumentCurrentValueCold;

        public string InstrumentCurrentValueCold
        {
            get => _instrumentCurrentValueCold;
            set => SetField(ref _instrumentCurrentValueCold, value);
        }

        #endregion InstrumentCurrentValueCold : string - Текущие значения счётчика для ХВС

        #region InstrumentPreviousValueCold : string - Предыдущие значение счётчика для ХВС

        private string _instrumentPreviousValueCold = "lastValFromDb";

        public string InstrumentPreviousValueCold
        {
            get => _instrumentPreviousValueCold;
            set => SetField(ref _instrumentPreviousValueCold, value);
        }

        #endregion InstrumentPreviousValueCold : string - Предыдущие значение счётчика для ХВС

        #region NormPerPersonCold : string - Норма потребления на человека для ХВС

        private string _normPerPersonCold = "Default";

        public string NormPerPersonCold
        {
            get => _normPerPersonCold;
            set => SetField(ref _normPerPersonCold, value);
        }

        #endregion NormPerPersonCold : string - Норма потребления на человека для ХВС

        #endregion Подблок - Холодное водоснабжение

        #region Подблок - Горячее водоснабжение

        #region IsMeteringDevicesHotSelected : bool - Состояние чекбокса приборов для ГВС

        private bool _isMeteringDevicesHotSelected = true;

        public bool IsMeteringDevicesHotSelected
        {
            get => _isMeteringDevicesHotSelected;
            set
            {
                SetField(ref _isMeteringDevicesHotSelected, value);
                SetField(ref _isStandardVolumeHotSelected, !_isMeteringDevicesHotSelected);
                OnPropertyChanged(nameof(IsStandardVolumeHotSelected));
            }
        }

        #endregion IsMeteringDevicesHotSelected : bool - Состояние чекбокса приборов для ГВС

        #region IsStandardVolumeHotSelected : bool - Состояние чекбокса нормативного объёма для ГВС

        private bool _isStandardVolumeHotSelected;

        public bool IsStandardVolumeHotSelected
        {
            get => _isStandardVolumeHotSelected;
            set
            {
                SetField(ref _isStandardVolumeHotSelected, value);
                SetField(ref _isMeteringDevicesHotSelected, !_isStandardVolumeHotSelected);
                OnPropertyChanged(nameof(IsMeteringDevicesHotSelected));
            }
        }

        #endregion IsStandardVolumeHotSelected : bool - Состояние чекбокса нормативного объёма для ГВС

        #region InstrumentCurrentValueHot : string - Текущие значения счётчика для ГВС

        private string _instrumentCurrentValueHot;

        public string InstrumentCurrentValueHot
        {
            get => _instrumentCurrentValueHot;
            set => SetField(ref _instrumentCurrentValueHot, value);
        }

        #endregion InstrumentCurrentValueHot : string - Текущие значения счётчика для ГВС

        #region InstrumentPreviousValueHot : string - Предыдущие значение счётчика для ГВС

        private string _instrumentPreviousValueHot = "lastValFromDb";

        public string InstrumentPreviousValueHot
        {
            get => _instrumentPreviousValueHot;
            set => SetField(ref _instrumentPreviousValueHot, value);
        }

        #endregion InstrumentPreviousValueHot : string - Предыдущие значение счётчика для ГВС

        #region NormPerPersonHot : string - Норма потребления на человека для ГВС

        private string _normPerPersonHot = "Default";

        public string NormPerPersonHot
        {
            get => _normPerPersonHot;
            set => SetField(ref _normPerPersonHot, value);
        }

        #endregion NormPerPersonHot : string - Норма потребления на человека для ГВС

        #endregion Подблок - Горячее водоснабжение

        #endregion Блок - Показания приборов
    }
}