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
            new ModalAgent() { DataContext = Humans.SelectedItem }.ShowDialog();
        }

        void Add_Click(object o, RoutedEventArgs e)
        {
            return;
            realEstate.agents.Add(new agent());
        }
        void Remove_Click(object o, RoutedEventArgs e)
        {
            return;
            if (Humans.SelectedItem == null) return;
            realEstate.agents.Remove(Humans.SelectedItem as agent);
        }
    }
}