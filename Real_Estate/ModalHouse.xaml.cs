using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate.Real_Estate
{
    public partial class ModalHouse : Window
    {
        public ModalHouse(house house)
        {
            InitializeComponent();
            DataContext = house;
            if (house.land == null)
            {
                house.land = new land() { TypeId = 1 };
                house.land.Address = new Address();
            }
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (City.Text != "" && Street.Text != "")
            {
                if (DataContext != null && DataContext is house house)
                    Query.query(() =>
                    {
                        Query.real.Addresses.AddOrUpdate(house.land.Address);
                        Query.real.lands.AddOrUpdate(house.land);
                        Query.real.houses.AddOrUpdate(house);
                        Query.real.SaveChanges();
                    }, "Добалвение или обновление дома");
            }
            else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}