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

        //Properties        
        public DBHandler Handler
        {
            get { return handler; }
            set { handler = value; }
        }

        //Constructors
        public DataController(string conString){}

        //Methods
        public List<IPersistable> GetEntities(string entity)
        {

        }

        public IPersistable GetEntity(string entity, int id)
        {

        }

        public bool NewEntity(IPersistable entity)
        {

        }

        public bool UpdateEntity(IPersistable entity)
        {

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
