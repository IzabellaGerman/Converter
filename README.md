# Currency Converter

A WPF desktop application for converting between 30 world currencies with a custom dark-themed UI.

## Features

- Real-time currency conversion as you type
- 30 currencies with country flag emojis
- Scrollable dropdown selectors
- Live exchange rate display
- Input validation (numbers and decimals only)
- Custom dark theme with animations
- MVVM architecture

## Supported Currencies

EUR, USD, GBP, CHF, CZK, PLN, SEK, NOK, DKK, HUF, RON, BGN, HRK, RUB, UAH, TRY, JPY, CNY, KRW, INR, CAD, AUD, NZD, BRL, MXN, ZAR, SGD, HKD, THB, AED

## Tech Stack

- .NET 8
- WPF
- C#
- Emoji.Wpf (for flag rendering)

## How to Run

```
dotnet build
dotnet run --project Converter
```

## Project Structure

```
Converter/
  MVVM/
    Model/          - CurrencyConverter (rates & conversion logic)
    View/           - MainWindow (UI)
    ViewModel/      - MainViewModel, RelayCommand, FlagConverter
  Theme/            - Custom styles (TextBox, Button, ScrollBar, etc.)
```

