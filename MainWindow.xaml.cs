using RealEstate.Agent;
using RealEstate.Client;
using System.Windows;

namespace RealEstate
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        void Agents_Click(object o, RoutedEventArgs e) => new ManageAgents().ShowDialog();
        void Clients_Click(object o, RoutedEventArgs e) => new ManageClients().ShowDialog();
        void RealEstate_Click(object o, RoutedEventArgs e) => new Real_Estate.Real_Estate().ShowDialog();
    }
}