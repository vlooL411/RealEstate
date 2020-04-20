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
                if (agent.human != null)
                    return $"{agent.human.FirstName} {agent.human.MiddleName} {agent.human.LastName}";
                else return "Все";
            if (value is client client)
                if (client.human != null)
                    return $"{client.human.FirstName} {client.human.MiddleName} {client.human.LastName}";
                else return "Все";
            if (value is human human)
                return $"{human.FirstName} {human.MiddleName} {human.LastName}";
            if (value is Address a)
                return $"{a.City}, {a.Street}, {a.House}, {a.Number}";
            if (value is land l)
                if (l.Address != null)
                    return $"{TypeRealestate(l.TypeId)} {l.Address.City}, {l.Address.Street}, {l.Address.House}, {l.Address.Number}";
                else return "Все";
            if (value is land_demand landD && (string)parameter == "all")
                if (landD.Address != null)
                    return $"{TypeRealestate(landD.TypeId)} {landD.Address.City}, {landD.Address.Street}, {landD.Address.House}, {landD.Address.Number}";
                else return "Все";

            if (value is type_realestate type) return TypeRealestate(type.Id);
            return null;
        }
        string TypeRealestate(byte? id)
        {
            switch (id)
            {
                case null:
                case 0: return "Земля";
                case 1: return "Дом";
                case 2: return "Квартира";
            };
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}