using System.Linq;
using System.Windows;

namespace RealEstate.Client
{
    public partial class ManageClients : Window
    {
        public ManageClients()
        {
            InitializeComponent();
            Update();
        }
        void Update() => Query.query(() => Humans.ItemsSource = Query.real.clients.ToList(), "Загрузка и обновление списка клиентов");
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) return;
            new ModalClient(Humans.SelectedItem as client).ShowDialog();
            Update();
        }
        void Add_Click(object o, RoutedEventArgs e)
        {
            new ModalClient(new client()).ShowDialog();
            Update();
        }
        void Remove_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) { MessageBox.Show("Выберите элемент!!!", "Внимание"); return; }
            if (MessageBox.Show("Вы хотите удалите?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Query.query(() => Query.real.clients.Add(Humans.SelectedItem as client), "Удаление клиента");
                Update();
            }
        }
    }
}