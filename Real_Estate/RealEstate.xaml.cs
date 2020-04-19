using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RealEstate.Real_Estate
{
    public partial class Real_Estate : Window
    {
        RealEstateEntities realEstate = new RealEstateEntities();
        public Real_Estate()
        {
            InitializeComponent();
            Query.query(() => RealEstates.ItemsSource = Query.real.lands.ToList(), "Загрузка недвижимости");
        }
        void AddApartment_Click(object o, RoutedEventArgs e) => new ModalApartment(new apartment()).ShowDialog();
        void AddHouse_Click(object o, RoutedEventArgs e) => new ModalHouse(new house()).ShowDialog();
        void AddLand_Click(object o, RoutedEventArgs e) => new ModalLand(new land()).ShowDialog();
        void Remove_Click(object o, RoutedEventArgs e)
        {
            if (RealEstates.SelectedItem == null) { MessageBox.Show("Выберите элемент!!!", "Внимание"); return; }
            if (MessageBox.Show("Вы хотите удалите?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Query.query(() =>
                {
                    var land = RealEstates.SelectedItem as land;
                    land.houses.Clear();
                    land.apartments.Clear();
                    land.supplies.Clear();
                    Query.real.lands.Remove(land);
                }, "Удаление недвижимости");
        }
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (RealEstates.SelectedItem == null) return;

            if (RealEstates.SelectedItem is apartment a)
                new ModalApartment(a).ShowDialog();
            else if (RealEstates.SelectedItem is house h)
                new ModalHouse(h).ShowDialog();
            else if (RealEstates.SelectedItem is land l)
                new ModalLand(l).ShowDialog();
        }
    }
}