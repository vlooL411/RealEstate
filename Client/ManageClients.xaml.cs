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
            new ModalClient() { DataContext = Humans.SelectedItem }.ShowDialog();
        }
        void Add_Click(object o, RoutedEventArgs e)
        {
            return;
            realEstate.clients.Add(new client());
        }
        void Remove_Click(object o, RoutedEventArgs e)
        {
            return;
            if (Humans.SelectedItem == null) return;
            realEstate.clients.Remove(Humans.SelectedItem as client);
        }
    }
}