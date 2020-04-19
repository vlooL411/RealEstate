using System;
using System.Data.Entity.Migrations;
using System.Windows;

namespace RealEstate
{
    static class Query
    {
        static public RealEstateEntities real = new RealEstateEntities();
        static public void query(Action action, string message = "")
        {
            try { action?.Invoke(); }
            catch (Exception ex) { MessageBox.Show($"{message}\nОшибка соединения с БД\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        static public void Save(string message = "") => query(() => real.SaveChanges(), "Сохранение не выполнено\n" + message);
    }
}