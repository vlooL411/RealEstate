using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace RealEstate.Demand
{
    public partial class ModalDemand : Window
    {
        public ModalDemand(demand supply)
        {
            InitializeComponent();
            DataContext = supply;
            Query.query(async () =>
            {
                client.ItemsSource = await Query.real.clients.ToListAsync();
                agent.ItemsSource = await Query.real.agents.ToListAsync();
                realestate.ItemsSource = await Query.real.land_demand.Where(l => l.Address != null).ToListAsync();
            }, "Загрузка клиентов, агентов, недвижимостей");
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (DataContext != null)
                if (client.SelectedItem != null && agent.SelectedItem != null && realestate.SelectedItem != null
                    && ((MinPrice.Text != "" && MinPrice != null) || (MaxPrice.Text != "" && MaxPrice.Text != null)))
                    Query.query(() =>
                    {
                        Query.real.demands.AddOrUpdate(DataContext as demand);
                        Query.real.SaveChanges();
                    }, "Добавдение потребностей");
                else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}