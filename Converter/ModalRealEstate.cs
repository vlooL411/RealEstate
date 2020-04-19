using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RealEstate.Converter
{
    class ModalRealEstate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is land) return Visibility.Collapsed;
            if (value is apartment) return Visibility.Visible;
            if (value is house && (string)parameter == "room") return Visibility.Collapsed;
            return Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
    class ModalRealEstateHA : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is house h && (string)parameter == "floor") return h.TotalFloors;
            if (value is apartment a && (string)parameter == "floor") return a.Floor;
            if (value is house && (string)parameter == "floorString") return "Этажи";
            return "Этаж";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}