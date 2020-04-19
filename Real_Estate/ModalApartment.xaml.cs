using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate.Real_Estate
{
    public partial class ModalApartment : Window
    {
        public ModalApartment(apartment apartment)
        {
            InitializeComponent();
            DataContext = apartment;
            if (apartment.land == null)
            {
                apartment.land = new land() { TypeId = 2 };
                apartment.land.Address = new Address();
            }
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (City.Text != "" && Street.Text != "")
            {
                if (DataContext != null && DataContext is apartment apartment)
                    Query.query(() =>
                    {
                        Query.real.Addresses.AddOrUpdate(apartment.land.Address);
                        Query.real.lands.AddOrUpdate(apartment.land);
                        Query.real.apartments.AddOrUpdate(apartment);
                        Query.real.SaveChanges();
                    }, "Добалвение или обновление квартиры");
            }
            else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}