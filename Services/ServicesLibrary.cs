using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Services
{
    public class GetWeatherForecast
    {
        //Fields
        private string url;
        private string apiKey;

        //Properties
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
        public string APIKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }

        //Constructors
        public GetWeatherForecast(string url, string apiKey)
        {
            URL = url;
            APIKey = apiKey;
        }

        //Methods
        public WeatherData TodaysWeather()
        {
            //PLS FIX !!!!!!
            WeatherData weather = new WeatherData();
            return weather;
        }

        public WeatherData TomorrowsWeather()
        {
            //PLS FIX !!!!!!
            WeatherData weather = new WeatherData();
            return weather;
        }

    }

    public struct WeatherData
    {
        //Fields
        private string city;
        private string temperatur;
        private string forecast;        

        //Properties
        public string Forecast
        {
            get { return forecast; }
            set { forecast = value; }
        }

        public string Temperature
        {
            get { return temperatur; }
            set { temperatur = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        //Constructors
        public WeatherData(string forecast, string temperature, string city) : this()
        {
            Forecast = forecast;
            Temperature = temperature;
            City = city;
        }

        //Methods
        public override string ToString()
        {
            return $"By: {City} Temperatur: {Temperature} Prognose: {Forecast}";
        }
    }
}
