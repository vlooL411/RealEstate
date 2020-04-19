using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate.Agent
{
    public partial class ModalAgent : Window
    {
        public ModalAgent(agent agent)
        {
            InitializeComponent();
            DataContext = agent;
            if (agent?.human == null)
                agent.human = new human();
        }
        void Save_Click(object o, RoutedEventArgs e)
        {
            if (FirstName.Text != "" && MiddleName.Text != "" && DealShare.Text != "")
            {
                if (DataContext != null && DataContext is agent agent)
                    Query.query(() =>
                    {
                        Query.real.humen.AddOrUpdate(agent.human);
                        Query.real.agents.AddOrUpdate(agent);
                        Query.real.SaveChanges();
                    }, "Добалвение или обновление агента");
            }
            else MessageBox.Show("Введите все данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}