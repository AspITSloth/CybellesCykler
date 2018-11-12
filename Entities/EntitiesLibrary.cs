using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rentee : IPersistable
    {
        //Fields
        private string name;
        private string address;
        private string phoneNumber;
        private DateTime registerDate;
        private int id;

        //Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        //Constructors
        public Rentee(int id, DateTime registerDate, string phoneNumber, string address, string name)
        {
            ID = id;
            RegisterDate = registerDate;
            PhoneNumber = phoneNumber;
            Address = address;
            Name = name;
        }

        //Methods
        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public class Order : IPersistable
    {
        //Fields
        private Bike bike;
        private Rentee rentee;
        private DateTime rentDate;
        private DateTime deliveryDate;
        private int id;

        //Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        public DateTime RentDate
        {
            get { return rentDate; }
            set { rentDate = value; }
        }

        public Rentee Rentee
        {
            get { return rentee; }
            set { rentee = value; }
        }

        public Bike Bike
        {
            get { return bike; }
            set { bike = value; }
        }

        //Constructors
        public Order(int id, DateTime deliveryDate, DateTime rentDate, Rentee rentee, Bike bike)
        {
            ID = id;
            DeliveryDate = deliveryDate;
            RentDate = rentDate;
            Rentee = rentee;
            Bike = bike;
        }

        //Methods
        public override string ToString()
        {
            return $"Lejer: {Rentee} Cykel: {Bike.Kind}";
        }
        public decimal GetPrice()
        {
            return 0;
        }
    }

    public class Bike : IPersistable
    {
        //Fields
        private decimal pricePerDay;
        private string bikeDescription;
        private BikeKind kind;
        private int id;        

        //Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public BikeKind Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public string BikeDescription
        {
            get { return bikeDescription; }
            set { bikeDescription = value; }
        }

        public decimal PricePerDay
        {
            get { return pricePerDay; }
            set { pricePerDay = value; }
        }

        //Constructors
        public Bike(int iD, BikeKind kind, string bikeDescription, decimal pricePerDay)
        {
            ID = iD;
            Kind = kind;
            BikeDescription = bikeDescription;
            PricePerDay = pricePerDay;
        }
    }

    public enum BikeKind
    {        
        Mountain,
        City,
        Tandem,
        Unicycle,
        PennyFarthing,
        PediCab
    }

    public interface IPersistable
    {
        int ID { get; set; }
    }
}
