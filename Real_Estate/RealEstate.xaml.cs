using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RealEstate.Real_Estate
{
    public partial class Real_Estate : Window
    {
        RealEstateEntities realEstate = new RealEstateEntities();
        public Real_Estate()
        {
            InitializeComponent();
            var realEstates = new List<object>();
            realEstates.AddRange(realEstate.apartments);
            realEstates.AddRange(realEstate.houses);
            realEstates.AddRange(realEstate.lands);
            RealEstates.ItemsSource = realEstates;
        }
        void Add_Click(object o, RoutedEventArgs e)
        {
            switch ((o as Button).Tag)
            {
                case "apartment": new ModalApartment().ShowDialog(); break;
                case "house": new ModalHouse().ShowDialog(); break;
                case "land": new ModalLand().ShowDialog(); break;
            }
        }
        void Remove_Click(object o, RoutedEventArgs e)
        {
            return;
            if (o is apartment a) realEstate.apartments.Remove(a);
            if (o is house h) realEstate.houses.Remove(h);
            if (o is land l) realEstate.lands.Remove(l);
        }
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (RealEstates.SelectedItem == null) return;
            if (RealEstates.SelectedItem is apartment a) 
                new ModalApartment() { DataContext = a }.ShowDialog();
            else if (RealEstates.SelectedItem is house h) 
                new ModalHouse() { DataContext = h }.ShowDialog();
            else if (RealEstates.SelectedItem is land l) 
                new ModalLand() { DataContext = l }.ShowDialog();
        }
    }
}