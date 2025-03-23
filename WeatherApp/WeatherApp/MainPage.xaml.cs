using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {

        const string API_Key = "4ca58ca50535c589be6c4de05142f29c";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void get_weather_Clicked(object sender, EventArgs e)
        {
            string city = input_city.Text.Trim();
            if (city.Length < 2)
            {
                await DisplayAlert("Error", "City name used to be bigger", "Okay");
                return;
            }
            HttpClient client = new HttpClient();
            string urladdress = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_Key}&units=metric";
            string response = await client.GetStringAsync(urladdress);
            
            var json = JObject.Parse(response);
            string temp = json["main"]["temp"].ToString();
            result_label.Text = "Погода сейчас " + temp;
        }

        private async void switchToCat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new cats());
        }

     
    }
}
