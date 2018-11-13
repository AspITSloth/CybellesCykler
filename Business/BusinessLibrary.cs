using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Services;

namespace Business
{
    public class DataController
    {
        //Fields
        private DBHandler handler;        
        
        //Constructors
        public DataController(string conString)
        {
            handler = new DBHandler(conString);            
        }

        //Methods
        public List<IPersistable> GetEntities(string entity)
        {
            List<IPersistable> entities;
            switch (entity)
            {
                case "Rentee":
                    entities = handler.GetRentees();
                    break;
                case "Order":
                    entities = handler.GetOrders();
                    break;
                case "Bike":
                    entities = handler.GetBikes();
                    break;
                default:
                    entities = null;
                    break;
            }
            return entities;
        }

        public IPersistable GetEntity(string entity, int id)
        {
            IPersistable returnEntity;
            switch (entity)
            {
                case "Rentee":
                    returnEntity = handler.GetRentee(id);
                    break;
                case "Order":
                    returnEntity = handler.GetOrder(id);
                    break;
                case "Bike":
                    returnEntity = handler.GetBike(id);
                    break;
                default:
                    returnEntity = null;
                    break;
            }
            return returnEntity;
        }

        public bool NewEntity(IPersistable entity)
        {
            if (entity.GetType() == typeof(Rentee))
            {
                return handler.NewRentee(entity as Rentee);
            }
            else if (entity.GetType() == typeof(Order))
            {
                return handler.NewOrder(entity as Order);
            }
            else if (entity.GetType() == typeof(Bike))
            {
                return handler.NewBike(entity as Bike);                
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEntity(IPersistable entity)
        {
            if (entity.GetType() == typeof(Rentee))
            {
                return handler.UpdateRentee(entity as Rentee);
            }
            else if (entity.GetType() == typeof(Order))
            {
                return handler.UpdateOrder(entity as Order);
            }
            else if (entity.GetType() == typeof(Bike))
            {
                return handler.UpdateBike(entity as Bike);
            }
            else
            {
                return false;
            }
        }
    }

    public class WeatherController
    {
        //Fields
        private readonly string url = @"http://api.openweathermap.org/data/2.5/weather?q=denmark&units=metric&appid={apiKey}";
        private readonly string apiKey = "0c4f4ae5cfac7f593a52e7526d9aa611";

        //Properties
        public string APIKey
        {
            get { return apiKey; }            
        }

        public string URL
        {
            get { return url; }            
        }

        //Constructors
        public WeatherController(string url, string apiKey)
        {
            
        }

        //Methods
        public WeatherData TodaysWeather()
        {

        }

        public WeatherData TomorrowsWeather()
        {

        }
    }
}
