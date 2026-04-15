using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Converter.MVVM.Model;

namespace Converter.MVVM.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private string _firstAmount = "0";
    private string _secondAmount = "0";
    private string _firstCurrency = "EUR";
    private string _secondCurrency = "USD";
    private bool _isFirstDropdownOpen;
    private bool _isSecondDropdownOpen;
    private bool _isUpdating;

    public string[] Currencies => CurrencyConverter.Currencies;

    public string FirstCurrencyDisplay =>
        $"{CurrencyConverter.GetFlag(_firstCurrency)} {_firstCurrency}";

    public string SecondCurrencyDisplay =>
        $"{CurrencyConverter.GetFlag(_secondCurrency)} {_secondCurrency}";

    public string FirstAmount
    {
        get => _firstAmount;
        set
        {
            value = CleanLeadingZero(value);
            if (_firstAmount == value) return;
            _firstAmount = value;
            OnPropertyChanged();
            ConvertFirstToSecond();
        }
    }

    public string SecondAmount
    {
        get => _secondAmount;
        set
        {
            value = CleanLeadingZero(value);
            if (_secondAmount == value) return;
            _secondAmount = value;
            OnPropertyChanged();
            ConvertSecondToFirst();
        }
    }

    private static string CleanLeadingZero(string value)
    {
        // "05" -> "5", but keep "0" and "0.5" as-is
        if (value.Length > 1 && value[0] == '0' && value[1] != '.' && value[1] != ',')
            return value.TrimStart('0');
        return value;
    }

    public string FirstCurrency
    {
        get => _firstCurrency;
        set
        {
            if (_firstCurrency == value) return;
            _firstCurrency = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FirstCurrencyDisplay));
            OnPropertyChanged(nameof(RateDisplay));
            ConvertFirstToSecond();
        }
    }

    public string SecondCurrency
    {
        get => _secondCurrency;
        set
        {
            if (_secondCurrency == value) return;
            _secondCurrency = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SecondCurrencyDisplay));
            OnPropertyChanged(nameof(RateDisplay));
            ConvertFirstToSecond();
        }
    }

    public string RateDisplay =>
        $"1 {CurrencyConverter.GetFlag(_firstCurrency)} {_firstCurrency} = {CurrencyConverter.Convert(1m, _firstCurrency, _secondCurrency)} {CurrencyConverter.GetFlag(_secondCurrency)} {_secondCurrency}";

    public bool IsFirstDropdownOpen
    {
        get => _isFirstDropdownOpen;
        set { _isFirstDropdownOpen = value; OnPropertyChanged(); }
    }

    public bool IsSecondDropdownOpen
    {
        get => _isSecondDropdownOpen;
        set { _isSecondDropdownOpen = value; OnPropertyChanged(); }
    }

    public ICommand ToggleFirstDropdownCommand { get; }
    public ICommand ToggleSecondDropdownCommand { get; }
    public ICommand SelectFirstCurrencyCommand { get; }
    public ICommand SelectSecondCurrencyCommand { get; }

    public MainViewModel()
    {
        ToggleFirstDropdownCommand = new RelayCommand(_ =>
        {
            IsFirstDropdownOpen = !IsFirstDropdownOpen;
            IsSecondDropdownOpen = false;
        });

        ToggleSecondDropdownCommand = new RelayCommand(_ =>
        {
            IsSecondDropdownOpen = !IsSecondDropdownOpen;
            IsFirstDropdownOpen = false;
        });

        SelectFirstCurrencyCommand = new RelayCommand(param =>
        {
            if (param is string currency)
            {
                FirstCurrency = currency;
                IsFirstDropdownOpen = false;
            }
        });

        SelectSecondCurrencyCommand = new RelayCommand(param =>
        {
            if (param is string currency)
            {
                SecondCurrency = currency;
                IsSecondDropdownOpen = false;
            }
        });
    }

    private void ConvertFirstToSecond()
    {
        if (_isUpdating) return;
        _isUpdating = true;

        if (decimal.TryParse(_firstAmount, out decimal amount))
        {
            var result = CurrencyConverter.Convert(amount, _firstCurrency, _secondCurrency);
            _secondAmount = result.ToString("0.##");
            OnPropertyChanged(nameof(SecondAmount));
        }

        _isUpdating = false;
    }

    private void ConvertSecondToFirst()
    {
        if (_isUpdating) return;
        _isUpdating = true;

        if (decimal.TryParse(_secondAmount, out decimal amount))
        {
            var result = CurrencyConverter.Convert(amount, _secondCurrency, _firstCurrency);
            _firstAmount = result.ToString("0.##");
            OnPropertyChanged(nameof(FirstAmount));
        }

        _isUpdating = false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
