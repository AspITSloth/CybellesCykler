using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entities;
using Business;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = CybellesCyklerDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataController dataController = new DataController(connectionString);

        private ObservableCollection<Rentee> renteesList = new ObservableCollection<Rentee>();
        private ObservableCollection<Bike> bikesList = new ObservableCollection<Bike>();   

        public ObservableCollection<Bike> BikesList
        {
            get { return bikesList; }
            set { bikesList = value; }
        }

        public ObservableCollection<Rentee> RenteesList
        {
            get { return renteesList; }
            set { renteesList = value; }
        }

        public MainWindow()
        {               
            InitializeComponent();
        }

        private void BtnShowRentees_Click(object sender, RoutedEventArgs e)
        {
            RenteesList.Clear();
            foreach (Rentee rentee in dataController.GetEntities("Rentee"))
            {
                RenteesList.Add(rentee);
            }
            DtgSelected.ItemsSource = RenteesList;
        }

        private void BtnShowBikes_Click(object sender, RoutedEventArgs e)
        {
            BikesList.Clear();
            foreach (Bike bike in dataController.GetEntities("Bike"))
            {
                BikesList.Add(bike);
            }
            DtgSelected.ItemsSource = BikesList;
        }

        private void BtnShowOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.ShowDialog();
            orders.Focus();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DtgSelected.ItemsSource == BikesList)
            {
                BikeAdd bikeAdd = new BikeAdd();
                bikeAdd.ShowDialog();
                bikeAdd.Focus();
            }
            else if (DtgSelected.ItemsSource == RenteesList)
            {
                RenteeAdd renteeAdd = new RenteeAdd();
                renteeAdd.ShowDialog();
                renteeAdd.Focus();
            }
            else
            {
                MessageBox.Show("Vælg listen af cykler eller lejere før du tilføjer elementer");
            }
        }
    }
}
