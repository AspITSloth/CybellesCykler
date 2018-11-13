using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entities;
using Business;
using System.Collections.ObjectModel;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = CybellesCyklerDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataController dataController = new DataController(connectionString);

        private ObservableCollection<Order> ordersList;

        public ObservableCollection<Order> OrdersList
        {
            get{ return ordersList; }
            set{ ordersList = value; }
        }

        public ObservableCollection<Order> GetOrders()
        {
            foreach (Order entity in dataController.GetEntities("Order"))
            {
                OrdersList.Add(entity);
            }
            return OrdersList;
        }

        public Orders()
        {            
            InitializeComponent();
            DataContext = this;
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Weather_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
