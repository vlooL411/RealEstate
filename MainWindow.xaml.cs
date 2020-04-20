using RealEstate.Agent;
using RealEstate.Client;
using RealEstate.Demand;
using RealEstate.Real_Estate;
using RealEstate.Supply;
using System.Windows;

namespace RealEstate
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        void Agents_Click(object o, RoutedEventArgs e) => new ManageAgents().ShowDialog();
        void Clients_Click(object o, RoutedEventArgs e) => new ManageClients().ShowDialog();
        void RealEstate_Click(object o, RoutedEventArgs e) => new ManageRealEstate().ShowDialog();
        void Supplies_Click(object o, RoutedEventArgs e) => new Supplies().ShowDialog();
        void Demand_Click(object o, RoutedEventArgs e) => new Demands().ShowDialog();
    }
}