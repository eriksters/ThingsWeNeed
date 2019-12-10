using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using ThingsWeNeed.Shared;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string THINGS_GET_COLLECTION = "https://localhost:44371/api/Things";

        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            List<ThingDto> things = new List<ThingDto>();
            fillThingsList();
        }

        private async void btnApi_Click(object sender, RoutedEventArgs e)
        {
            ThingDto thing = await GetThingAPIAsync("https://localhost:44371/api/Things/1");

            String sResult = "API Result on /api/Things/1: " + Environment.NewLine + "Name=" + thing.Name + Environment.NewLine + "Id=" + thing.ThingId;

            tbxApi.Text = sResult;
        }

        // Fill the Thing List with data fro Data Grid
        private async void fillThingsList()
        {
            ICollection<ThingDto> things = await GetThingCollectionAPIAsync(THINGS_GET_COLLECTION);
            dataGrid.ItemsSource = things;
        }


        // Get Thing by Id from API
        static async Task<ThingDto> GetThingAPIAsync(string path)
        {
            string responseBody = "";
            ThingDto thing = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                thing = JsonConvert.DeserializeObject<ThingDto>(responseBody);
            }

            return thing;
        }


        // Get Collection of Things from API
        static async Task<ICollection<ThingDto>> GetThingCollectionAPIAsync(string path)
        {
            string responseBody = "";
            ICollection<ThingDto> thingsResponse = new List<ThingDto>();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                thingsResponse = JsonConvert.DeserializeObject<ICollection<ThingDto>>(responseBody);
            }

            return thingsResponse;
        }
    }
}
