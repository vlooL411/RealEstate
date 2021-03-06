﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RealEstate.Demand
{
    public partial class Demands : Window
    {
        List<demand> demands = new List<demand>();
        public Demands()
        {
            InitializeComponent();
            Query.query(() =>
            {
                var cls = Query.real.clients.ToList();
                cls.Insert(0, new client());
                client.ItemsSource = cls;
                var ags = Query.real.agents.ToList();
                ags.Insert(0, new agent());
                agent.ItemsSource = ags;
                var ld = Query.real.land_demand.Where(l => l.Address != null).ToList();
                ld.Insert(0, new land_demand());
                realestate.ItemsSource = ld;
            });
            Update();
            ShowSupplyDeal.IsChecked = true;
            ShowSupplyDeal.Checked += CheckBox_Checked;
            ShowSupplyDeal.Unchecked += CheckBox_Unchecked;
        }
        void Update() => Query.query(() => RealEstates.ItemsSource = (demands = Query.real.demands.ToList()), "Загрузка клиентов, агентов, потребностей");

        void Add_Click(object o, RoutedEventArgs e)
        {
            new ModalDemand(new demand()).ShowDialog();
            Update();
        }
        void Remove_Click(object o, RoutedEventArgs e)
        {
            if (RealEstates.SelectedItem == null) { MessageBox.Show("Выберите элемент!!!", "Внимание"); return; }
            if ((RealEstates.SelectedItem as supply).deals.Count() != 0) { MessageBox.Show("Предложение участвует в сделке!!!", "Внимание"); return; }
            if (MessageBox.Show("Вы хотите удалите?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Query.query(() => Query.real.supplies.Remove(RealEstates.SelectedItem as supply), "Удаление предложения");
        }
        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (RealEstates.SelectedItem == null) return;
            if (RealEstates.SelectedItem is demand s)
            {
                new ModalDemand(s).ShowDialog();
                Update();
            }
        }
        void CheckBox_Checked(object o, RoutedEventArgs e) => Query.query(() => RealEstates.ItemsSource = (demands = Query.real.demands.ToList()), "Просмотр предложений c делами");
        void CheckBox_Unchecked(object o, RoutedEventArgs e) => Query.query(() => RealEstates.ItemsSource = (demands = Query.real.demands.Where(s => s.deals.Count() == 0).ToList()), "Просмотр предложений без делов");
        void Find_Click(object o, RoutedEventArgs e)
        {
            IEnumerable<demand> list = demands;
            if (agent.SelectedItem != null)
            {
                var ag = (agent.SelectedItem as agent);
                if (ag.human != null)
                    list = list.Where(s => s.AgentId == ag.Id);
            }
            if (client.SelectedItem != null)
            {
                var cl = (client.SelectedItem as client);
                if (cl.human != null)
                    list = list.Where(s => s.ClientId == cl.Id);
            }
            if (realestate.SelectedItem != null)
            {
                var re = (realestate.SelectedItem as land_demand);
                if (re.Address != null)
                    list = list.Where(s => s.land_demand.AddressId == re.Address.Id);
            }

            if (City.Text != null && City.Text != "")
                list = list.Where(s => s.land_demand.Address.City == City.Text);
            if (Street.Text != null && Street.Text != "")
                list = list.Where(s => s.land_demand.Address.Street == Street.Text);
            if (House.Text != null && House.Text != "" && int.TryParse(House.Text, out var house))
                list = list.Where(s => s.land_demand.Address.House == house);
            if (Number.Text != null && Number.Text != "" && int.TryParse(Number.Text, out var number))
                list = list.Where(s => s.land_demand.Address.Number == number);

            if (MinPrice.Text != null && MinPrice.Text != "" && decimal.TryParse(MinPrice.Text, out var minPrice))
                list = list.Where(s => s.MinPrice >= minPrice);
            if (MaxPrice.Text != null && MaxPrice.Text != "" && decimal.TryParse(MaxPrice.Text, out var maxPrice))
                list = list.Where(s => s.MaxPrice <= maxPrice);

            RealEstates.ItemsSource = null;
            RealEstates.ItemsSource = list;
        }
    }
}