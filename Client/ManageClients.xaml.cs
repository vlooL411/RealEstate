using System.Linq;
using System.Windows;

namespace RealEstate.Client
{
    public partial class ManageClients : Window
    {
        static RealEstateEntities realEstate = new RealEstateEntities();
        public ManageClients()
        {
            InitializeComponent();
            Humans.ItemsSource = realEstate.clients.ToList();
        }
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) return;
            new ModalClient(Humans.SelectedItem as client).ShowDialog();
        }
        void Add_Click(object o, RoutedEventArgs e) => new ModalClient(new client()).ShowDialog();
        void Remove_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) { MessageBox.Show("Выберите элемент!!!", "Внимание"); return; }
            if (MessageBox.Show("Вы хотите удалите?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Query.query(() => realEstate.clients.Add(Humans.SelectedItem as client), "Удаление клиента");
        }
    }
}