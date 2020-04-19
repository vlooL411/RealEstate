using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate.Real_Estate
{
    public partial class ModalLand : Window
    {
        public ModalLand(land land)
        {
            InitializeComponent();
            land.TypeId = 0;
            DataContext = land;
            if (land?.Address == null)
                land.Address = new Address();
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (City.Text != "" && Street.Text != "")
            {
                if (DataContext != null && DataContext is land land)
                    Query.query(() =>
                    {
                        Query.real.Addresses.AddOrUpdate(land.Address);
                        Query.real.lands.AddOrUpdate(land);
                        Query.real.SaveChanges();
                    }, "Добалвение или обновление земли");
            }
            else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}