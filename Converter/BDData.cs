using System;
using System.Globalization;
using System.Windows.Data;

namespace RealEstate.Converter
{
    class BDData : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is agent agent)
                return $"{agent.human.FirstName} {agent.human.MiddleName} {agent.human.LastName}";
            if (value is client client)
                return $"{client.human.FirstName} {client.human.MiddleName} {client.human.LastName}";
            if (value is Address a)
                return $"{a.City}, {a.Street}, {a.House}, {a.Number}";
            if (value is type_realestate type)
                switch (type.Id)
                {
                    case 0: return "Земля";
                    case 1: return "Дом";
                    case 2: return "Квартира";
                };
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}