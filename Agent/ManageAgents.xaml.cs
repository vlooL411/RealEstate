using System.Linq;
using System.Windows;

namespace RealEstate.Agent
{
    public partial class ManageAgents : Window
    {
        public ManageAgents()
        {
            InitializeComponent();
            Update();
        }
        void Update() => Query.query(() => Humans.ItemsSource = Query.real.agents.ToList(), "Загрузка и обновление списка агентов");
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) return;
            new ModalAgent(Humans.SelectedItem as agent).ShowDialog();
            Update();
        }
        void Add_Click(object o, RoutedEventArgs e)
        {
            new ModalAgent(new agent()).ShowDialog();
            Update();
        }
        void Remove_Click(object o, RoutedEventArgs e)
        {
            if (Humans.SelectedItem == null) { MessageBox.Show("Выберите элемент!!!", "Внимание"); return; }
            if (MessageBox.Show("Вы хотите удалите?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Query.query(() => Query.real.agents.Add(Humans.SelectedItem as agent), "Удаление клиента");
            Update();
        }
    }
}