using System.Linq;
using System.Windows;

namespace RealEstate.Agent
{
    public partial class ManageAgents : Window
    {
        static RealEstateEntities realEstate = new RealEstateEntities();
        public ManageAgents()
        {
            InitializeComponent();
            Humans.ItemsSource = realEstate.agents.ToList();
        }
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) return;
            new ModalAgent(Humans.SelectedItem as agent).ShowDialog();
        }
        void Add_Click(object o, RoutedEventArgs e) => new ModalAgent(new agent()).ShowDialog();
        void Remove_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) { MessageBox.Show("Выберите элемент!!!", "Внимание"); return; }
            if (MessageBox.Show("Вы хотите удалите?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Query.query(() => realEstate.agents.Add(Humans.SelectedItem as agent), "Удаление клиента");
        }
    }
}