using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate.Client
{
    public partial class ModalClient : Window
    {
        public ModalClient(client client)
        {
            InitializeComponent();
            DataContext = client;
            if (client?.human == null)
                client.human = new human();
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (FirstName.Text != "" && MiddleName.Text != "" && (Phone.Text != "" || Email.Text != ""))
            {
                if (DataContext != null && DataContext is client client)
                    Query.query(() =>
                    {
                        Query.real.humen.AddOrUpdate(client.human);
                        Query.real.clients.AddOrUpdate(client);
                        Query.real.SaveChanges();
                    }, "Добалвение или обновление клиента");
            }
            else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}