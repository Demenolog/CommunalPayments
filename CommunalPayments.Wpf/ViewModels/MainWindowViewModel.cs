using System;
using CommunalPayments.Wpf.Infrastructure.Commands;
using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.Models;
using CommunalPayments.Wpf.Services;
using CommunalPayments.Wpf.ViewModels.Base;
using System.Windows.Input;

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
            set
            {
                if (TextBoxValidationService.IsIntNumber(value))
                {
                    SetField(ref _numberResidents, value);
                }
            }
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
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentCurrentValueCold, value);
                }
            }
        }

        #endregion InstrumentCurrentValueCold : string - Текущие значения счётчика для ХВС

        #region InstrumentPreviousValueCold : string - Предыдущие значение счётчика для ХВС

        private string _instrumentPreviousValueCold;

        public string InstrumentPreviousValueCold
        {
            get => _instrumentPreviousValueCold;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentPreviousValueCold, value);
                }
            }
        }

        #endregion InstrumentPreviousValueCold : string - Предыдущие значение счётчика для ХВС

        #region NormPerPersonCold : string - Норма потребления на человека для ХВС

        private string _normPerPersonCold = ColdWaterSupplyConstans.GetNormPerPerson().ToString();

        public string NormPerPersonCold
        {
            get => _normPerPersonCold;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _normPerPersonCold, value);
                }
            }
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
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentCurrentValueHot, value);
                }
            }
        }

        #endregion InstrumentCurrentValueHot : string - Текущие значения счётчика для ГВС

        #region InstrumentPreviousValueHot : string - Предыдущие значение счётчика для ГВС

        private string _instrumentPreviousValueHot;

        public string InstrumentPreviousValueHot
        {
            get => _instrumentPreviousValueHot;
            set => SetField(ref _instrumentPreviousValueHot, value);
        }

        #endregion InstrumentPreviousValueHot : string - Предыдущие значение счётчика для ГВС

        #region NormPerPersonHotHeatCarrier : string - Норма потребления на человека для «ГВС Теплоноситель»

        private string _normPerPersonHotHeatCarrier = HotWaterSupplyConstans.GetNormPerPersonHeatCarrier().ToString();

        public string NormPerPersonHotHeatCarrier
        {
            get => _normPerPersonHotHeatCarrier;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _normPerPersonHotHeatCarrier, value);
                }
            }
        }

        #endregion NormPerPersonHotHeatCarrier : string - Норма потребления на человека для «ГВС Теплоноситель»

        #region NormPerPersonHotHeatEnergy : string - Норма потребления на человека для «ГВС Теплоноситель»

        private string _normPerPersonHotHeatEnergy = HotWaterSupplyConstans.GetNormPerPersonHeatEnergy().ToString();

        public string NormPerPersonHotHeatEnergy
        {
            get => _normPerPersonHotHeatEnergy;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _normPerPersonHotHeatEnergy, value);
                }
            }
        }

        #endregion NormPerPersonHotHeatEnergy : string - Норма потребления на человека для «ГВС Теплоноситель»

        #region NormPerCubicMeter : string - Норма подогрева на 1 метр кубический

        private string _normPerCubicMeter = HotWaterSupplyConstans.GetNormPerCubicMeter().ToString();

        public string NormPerCubicMeter
        {
            get => _normPerCubicMeter;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _normPerCubicMeter, value);
                }
            }
        }

        #endregion NormPerCubicMeter : string - Норма подогрева на 1 метр кубический

        #endregion Подблок - Горячее водоснабжение

        #region Подблок - Электроэнергия

        #region IsMeteringDevicesEnergySelected : bool - Состояние чекбокса приборов для ЭЭ

        private bool _isMeteringDevicesEnergySelected = true;

        public bool IsMeteringDevicesEnergySelected
        {
            get => _isMeteringDevicesEnergySelected;
            set
            {
                SetField(ref _isMeteringDevicesEnergySelected, value);
                SetField(ref _isStandardVolumeEnergySelected, !_isMeteringDevicesEnergySelected);
                OnPropertyChanged(nameof(IsStandardVolumeEnergySelected));
            }
        }

        #endregion IsMeteringDevicesEnergySelected : bool - Состояние чекбокса приборов для ЭЭ

        #region IsStandardVolumeEnergySelected : bool - Состояние чекбокса нормативного объёма для ЭЭ

        private bool _isStandardVolumeEnergySelected;

        public bool IsStandardVolumeEnergySelected
        {
            get => _isStandardVolumeEnergySelected;
            set
            {
                SetField(ref _isStandardVolumeEnergySelected, value);
                SetField(ref _isMeteringDevicesEnergySelected, !_isStandardVolumeEnergySelected);
                OnPropertyChanged(nameof(IsMeteringDevicesEnergySelected));
            }
        }

        #endregion IsStandardVolumeEnergySelected : bool - Состояние чекбокса нормативного объёма для ЭЭ

        #region NormPerPersonEnergy : string - Норма потребления на человека для ЭЭ

        private string _normPerPersonEnergy = ElectricPowerSupplyConstans.GetNormPerPersonEnergy().ToString();

        public string NormPerPersonEnergy
        {
            get => _normPerPersonEnergy;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _normPerPersonEnergy, value);
                }
            }
        }

        #endregion NormPerPersonEnergy : string - Норма потребления на человека для ЭЭ

        #region InstrumentCurrentValueEnergyDay : string - Текущие значения счётчика для ЭЭ - дневная шкала

        private string _instrumentCurrentValueEnergyDay;

        public string InstrumentCurrentValueEnergyDay
        {
            get => _instrumentCurrentValueEnergyDay;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentCurrentValueEnergyDay, value);
                }
            }
        }

        #endregion InstrumentCurrentValueEnergyDay : string - Текущие значения счётчика для ЭЭ - дневная шкала

        #region InstrumentPreviousValueEnergyDay : string - Предыдущие значение счётчика для ЭЭ - дневная шкала

        private string _instrumentPreviousValueEnergyDay;

        public string InstrumentPreviousValueEnergyDay
        {
            get => _instrumentPreviousValueEnergyDay;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentPreviousValueEnergyDay, value);
                }
            }
        }

        #endregion InstrumentPreviousValueEnergyDay : string - Предыдущие значение счётчика для ЭЭ - дневная шкала

        #region InstrumentCurrentValueEnergyNight : string - Текущие значения счётчика для ЭЭ - ночная шкала

        private string _instrumentCurrentValueEnergyNight;

        public string InstrumentCurrentValueEnergyNight
        {
            get => _instrumentCurrentValueEnergyNight;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentCurrentValueEnergyNight, value);
                }
            }
        }

        #endregion InstrumentCurrentValueEnergyNight : string - Текущие значения счётчика для ЭЭ - ночная шкала

        #region InstrumentPreviousValueEnergyNight : string - Предыдущие значение счётчика для ЭЭ - ночная шкала

        private string _instrumentPreviousValueEnergyNight;

        public string InstrumentPreviousValueEnergyNight
        {
            get => _instrumentPreviousValueEnergyNight;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _instrumentPreviousValueEnergyNight, value);
                }
            }
        }

        #endregion InstrumentPreviousValueEnergyNight : string - Предыдущие значение счётчика для ЭЭ - ночная шкала

        #endregion Подблок - Электроэнергия

        #endregion Блок - Показания приборов

        #region Блок - Расчёт показаний

        #region Раздел - ХВС

        #region ConsumptionValueCold : string - Объём потребления ХВС

        private string _consumptionValueCold;

        public string ConsumptionValueCold
        {
            get => _consumptionValueCold;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _consumptionValueCold, value);
                }
            }
        }

        #endregion ConsumptionValueCold : string - Объём потребления ХВС

        #region RateCold : string - Тариф для ХВС

        private string _rateCold = ColdWaterSupplyConstans.GetRate().ToString();

        public string RateCold
        {
            get => _rateCold;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _rateCold, value);
                }
            }
        }

        #endregion RateCold : string - Тариф для ХВС

        #region ServiceChargesCold : string - Начисления за ХВС

        private string _serviceChargesCold;

        public string ServiceChargesCold
        {
            get => _serviceChargesCold;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _serviceChargesCold, value);
                }
            }
        }

        #endregion ServiceChargesCold : string - Начисления за ХВС

        #endregion Раздел - ХВС

        #region Раздел - ГВС

        #region ConsumptionValueHotHeatCarrier : string - Объем потребления «ГВС Теплоноситель»

        private string _consumptionValueHotHeatCarrier;

        public string ConsumptionValueHotHeatCarrier
        {
            get => _consumptionValueHotHeatCarrier;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _consumptionValueHotHeatCarrier, value);
                }
            }
        }

        #endregion ConsumptionValueHotHeatCarrier : string - Объем потребления «ГВС Теплоноситель»

        #region ConsumptionValueHotHeatEnergy : string - Объем потребления «ГВС Тепловая энергия»

        private string _consumptionValueHotHeatEnergy;

        public string ConsumptionValueHotHeatEnergy
        {
            get => _consumptionValueHotHeatEnergy;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _consumptionValueHotHeatEnergy, value);
                }
            }
        }

        #endregion ConsumptionValueHotHeatEnergy : string - Объем потребления «ГВС Тепловая энергия»

        #region HeatingStandard : string - Норматив на подогрев

        private string _heatingStandard;

        public string HeatingStandard
        {
            get => _heatingStandard;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _heatingStandard, value);
                }
            }
        }

        #endregion HeatingStandard : string - Норматив на подогрев

        #region RateHotHeatCarrier : string - Тариф для «ГВС Теплоноситель»

        private string _rateHotHeatCarrier = HotWaterSupplyConstans.GetRateHeatCarrier().ToString();

        public string RateHotHeatCarrier
        {
            get => _rateHotHeatCarrier;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _rateHotHeatCarrier, value);
                }
            }
        }

        #endregion RateHotHeatCarrier : string - Тариф для «ГВС Теплоноситель»

        #region RateHotHeatEnergy : string - Тариф для «ГВС Тепловая энергия»

        private string _rateHotHeatEnergy = HotWaterSupplyConstans.GetRateHeatEnergy().ToString();

        public string RateHotHeatEnergy
        {
            get => _rateHotHeatEnergy;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _rateHotHeatEnergy, value);
                }
            }
        }

        #endregion RateHotHeatEnergy : string - Тариф для «ГВС Тепловая энергия»

        #region ServiceChargesHotHeatCarrier : string - Начисления за «ГВС Теплоноситель»

        private string _serviceChargesHotHeatCarrier;

        public string ServiceChargesHotHeatCarrier
        {
            get => _serviceChargesHotHeatCarrier;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _serviceChargesHotHeatCarrier, value);
                }
            }
        }

        #endregion ServiceChargesHotHeatCarrier : string - Начисления за «ГВС Теплоноситель»

        #region ServiceChargesHotHeatEnergy : string - Начисления за «ГВС Теплоноситель»

        private string _serviceChargesHotHeatEnergy;

        public string ServiceChargesHotHeatEnergy
        {
            get => _serviceChargesHotHeatEnergy;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _serviceChargesHotHeatEnergy, value);
                }
            }
        }

        #endregion ServiceChargesHotHeatEnergy : string - Начисления за «ГВС Теплоноситель»

        #endregion Раздел - ГВС

        #region Раздел - ЭЭ

        #region ConsumptionValueEnergyGeneral : string - Общий объём потребления ЭЭ

        private string _consumptionValueEnergyGeneral;

        public string ConsumptionValueEnergyGeneral
        {
            get => _consumptionValueEnergyGeneral;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _consumptionValueEnergyGeneral, value);
                }
            }
        }

        #endregion ConsumptionValueEnergyGeneral : string - Общий объём потребления ЭЭ

        #region ConsumptionValueEnergyDay : string - Дневной объём потребления ЭЭ

        private string _consumptionValueEnergyDay;

        public string ConsumptionValueEnergyDay
        {
            get => _consumptionValueEnergyDay;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _consumptionValueEnergyDay, value);
                }
            }
        }

        #endregion ConsumptionValueEnergyDay : string - Дневной объём потребления ЭЭ

        #region ConsumptionValueEnergyNight : string - Ночной объём потребления ЭЭ

        private string _consumptionValueEnergyNight;

        public string ConsumptionValueEnergyNight
        {
            get => _consumptionValueEnergyNight;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _consumptionValueEnergyNight, value);
                }
            }
        }

        #endregion ConsumptionValueEnergyNight : string - Ночной объём потребления ЭЭ

        #region RateEnergyDay : string - Дневной тариф для ЭЭ

        private string _rateEnergyDay = ElectricPowerSupplyConstans.GetRateEnergyDay().ToString();

        public string RateEnergyDay
        {
            get => _rateEnergyDay;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _rateEnergyDay, value);
                }
            }
        }

        #endregion RateEnergyDay : string - Дневной тариф для ЭЭ

        #region RateEnergyNight : string - Ночной тариф для ЭЭ

        private string _rateEnergyNight = ElectricPowerSupplyConstans.GetRateEnergyNight().ToString();

        public string RateEnergyNight
        {
            get => _rateEnergyNight;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _rateEnergyNight, value);
                }
            }
        }

        #endregion RateEnergyNight : string - Ночной тариф для ЭЭ

        #region RateEnergyGeneral : string - Общий тариф для ЭЭ

        private string _rateEnergyGeneral = ElectricPowerSupplyConstans.GetRateEnergyGeneral().ToString();

        public string RateEnergyGeneral
        {
            get => _rateEnergyGeneral;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _rateEnergyGeneral, value);
                }
            }
        }

        #endregion RateEnergyGeneral : string - Общий тариф для ЭЭ

        #region ServiceChargesEnergy : string - Начисления за ЭЭ

        private string _serviceChargesEnergy;

        public string ServiceChargesEnergy
        {
            get => _serviceChargesEnergy;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _serviceChargesEnergy, value);
                }
            }
        }

        #endregion ServiceChargesEnergy : string - Начисления за ЭЭ

        #endregion Раздел - ЭЭ

        #region Раздел - Итого

        #region ServiceChargesTotal : string - Общая сумма начислений

        private string _serviceChargesTotal;

        public string ServiceChargesTotal
        {
            get => _serviceChargesTotal;
            set
            {
                if (TextBoxValidationService.IsIntOrDecNumber(value))
                {
                    SetField(ref _serviceChargesTotal, value);
                }
            }
        }

        #endregion ServiceChargesTotal : string - Общая сумма начислений

        #endregion Раздел - Итого

        #endregion Блок - Расчёт показаний

        #region Блок - Кнопоки

        #region MakeCalculation command

        public ICommand MakeCalculation { get; }

        private bool CanMakeCalculationExecuted(object p) => true;

        private void OnMakeCalculationExecute(object p)
        {
            try
            {
                CalculationСoldWaterSupply.Calculate(IsMeteringDevicesColdSelected);

                CalculationHotWaterSupply.Calculate(IsMeteringDevicesHotSelected);

                CalculationEnergySupply.Calculate(IsMeteringDevicesEnergySelected);

                CalculationServiceChargesTotal.Calculate();
            }
            catch (ArgumentNullException ex)
            {
                ClearCalculationService.Clear();
                UserAlertService.Error("Одна из строк пуста или имеет некорректный формат !");
            }
            catch (FormatException ex)
            {
                ClearCalculationService.Clear();
                UserAlertService.Error("Одна из строк пуста или имеет некорректный формат !");
            }
            catch (OverflowException ex)
            {
                UserAlertService.Error("Произошло переполнение одной из переменных !");
                throw;
            }
            catch (Exception ex)
            {
                UserAlertService.Error(ex.Message);
                throw;
            }
        }

        #endregion MakeCalculation command

        #region SaveCalculation command

        public ICommand SaveCalculation { get; }

        private bool CanSaveCalculationExecuted(object p) => true;

        private void OnSaveCalculationExecute(object p)
        {
            var year = CalculationYear;
            var month = CalculationMonth;

            DatabaseControlService.InsertData(year, month);
        }

        #endregion SaveCalculation command

        #region GetPreviousData command

        public ICommand GetPreviousData { get; }

        private bool CanGetPreviousDataExecuted(object p) => IsMeteringDevicesColdSelected && IsMeteringDevicesHotSelected && IsMeteringDevicesEnergySelected;

        private void OnGetPreviousDataExecute(object p)
        {
            var year = CalculationYear;
            var month = CalculationMonth;

            DatabaseControlService.GetPreviousData(year, month);
        }

        #endregion GetPreviousData command

        #region OpenDataViewWindow command

        public ICommand OpenDataViewWindow { get; }

        private bool CanOpenDataViewWindowExecuted(object p) => true;

        private void OnOpenDataViewWindowExecute(object p)
        {
            DataViewCreateWindowService.Create();

            DataViewCreateWindowService.Show();
        }

        #endregion OpenDataViewWindow command

        #region ClearCalculation command

        public ICommand ClearCalculation { get; }

        private bool CanClearCalculationExecuted(object p) => true;

        private void OnClearCalculationExecute(object p)
        {
            ClearCalculationService.Clear();
        }

        #endregion ClearCalculation command

        #endregion Блок - Кнопоки

        public MainWindowViewModel()
        {
            MakeCalculation = new LambdaCommand(OnMakeCalculationExecute, CanMakeCalculationExecuted);

            SaveCalculation = new LambdaCommand(OnSaveCalculationExecute, CanSaveCalculationExecuted);

            GetPreviousData = new LambdaCommand(OnGetPreviousDataExecute, CanGetPreviousDataExecuted);

            OpenDataViewWindow = new LambdaCommand(OnOpenDataViewWindowExecute, CanOpenDataViewWindowExecuted);

            ClearCalculation = new LambdaCommand(OnClearCalculationExecute, CanClearCalculationExecuted);
        }
    }
}