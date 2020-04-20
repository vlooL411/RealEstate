using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate.Supply
{
    public partial class ModalSupply : Window
    {
        public ModalSupply(supply supply)
        {
            InitializeComponent();
            DataContext = supply;
            Query.query(async () =>
            {
                client.ItemsSource = await Query.real.clients.ToListAsync();
                agent.ItemsSource = await Query.real.agents.ToListAsync();
                realestate.ItemsSource = await Query.real.lands.ToListAsync();
            }, "Загрузка клиентов, агентов, недвижимостей");
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (DataContext != null)
                if (client.SelectedItem != null && agent.SelectedItem != null && realestate.SelectedItem != null && price != null)
                    Query.query(() =>
                    {
                        Query.real.supplies.AddOrUpdate(DataContext as supply);
                        Query.real.SaveChanges();
                    }, "Добавдение потребностей");
                else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}