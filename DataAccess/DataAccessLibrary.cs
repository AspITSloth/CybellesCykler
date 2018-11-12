using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace DataAccess
{
    public class CommonDB
    {
        //Fields
        protected readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = CybellesCyklerDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //Constructors
        public CommonDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Methods
        protected DataSet ExecuteQuery(string query)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);
                }
                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected bool ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }

    public class DBHandler : CommonDB
    {
        //Constrcutor
        public DBHandler(string conString) : base(conString){}

        //Method
        public Rentee GetRentee(int id)
        {
            string query = $"SELECT * FROM Renters WHERE ID={id}";
            DataSet data = ExecuteQuery(query);

            DataRow row = data.Tables[0].Rows[0];
            
            Rentee rentee = new Rentee(
                (int)row["ID"], 
                (DateTime)row["RegisterDate"], 
                (string)row["PhoneNumber"], 
                (string)row["PhysAddress"], 
                (string)row["Name"]);

            return rentee;
        }

        public Order GetOrder(int id)
        {
            string query = $"SELECT * FROM Orders WHERE ID={id}";
            DataSet data = ExecuteQuery(query);

            DataRow row = data.Tables[0].Rows[0];

            Order order = new Order(
                (int)row["ID"], 
                (DateTime)row["DeliverDate"], 
                (DateTime)row["OrderDate"], 
                    new Bike(
                    (int)row["ID"], 
                    (BikeKind)row[""], 
                    (string)row["BikeDescription"], 
                    (decimal)row["PricePerDay"]));

            return order;
        }

        public Bike GetBike(int id)
        {
            string query = $"SELECT * FROM Renters WHERE ID={id}";
            DataSet data = ExecuteQuery(query);

            DataRow row = data.Tables[0].Rows[0];

            Bike bike = new Bike((int)row["ID"], (BikeKind)row[""], (string)row["BikeDescription"], (decimal)row["PricePerDay"]);
            return bike;
        }

        public bool NewRentee(Rentee rentee)
        {
            string query = $"INSERT INTO Renters(Name, PhoneNumber, PhysAddress, RegisterDate) VALUES ('{rentee.Name}'), ('{rentee.PhoneNumber}'), ('{rentee.Address}'), ({rentee.RegisterDate})";
            return ExecuteNonQuery(query);
        }

        public bool NewOrder(Order order)
        {
            string query = $"INSERT INTO Renters VALUES ('{}'), ('{}'), ('{}'), ({})";
            return ExecuteNonQuery(query);
        }

        public bool NewBike(Bike bike)
        {
            string query = $"INSERT INTO Renters VALUES ('{bike.BikeDescription}'), ('{bike.PricePerDay}')";
            return ExecuteNonQuery(query);
        }

        public bool UpdateRentee(Rentee rentee)
        {

        }

        public bool UpdateOrder(Order order)
        {

        }

        public bool UpdateBike(Bike bike)
        {

        }
    }
}
