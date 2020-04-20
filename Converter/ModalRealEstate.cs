using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace RealEstate.Converter
{
    class ModalRealEstate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is land l)
                if (l.TypeId == 0 || l.TypeId == 1 && (string)parameter == "room") return Visibility.Collapsed;
            return Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
    class ModalRealEstateHA : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is land l)
                switch (l?.TypeId)
                {
                    case 1:
                        if ((string)parameter == "floor") return l.houses?.First()?.TotalFloors;
                        if ((string)parameter == "floorString") return "Этажи";
                        break;
                    case 2:
                        if ((string)parameter == "floor") return l.apartments?.First()?.Floor;
                        return "Этаж";
                }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}