using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for ThingPage.xaml
    /// </summary>
    public partial class ThingPage : Page
    {
        static readonly string THINGS_GET_COLLECTION = "https://localhost:44371/api/Things";
        static HttpClient client = new HttpClient();
        static TwnContext twnContext = new TwnContext();
        MainWindow mainWindow;

        public ThingPage(MainWindow thingWindow)
        {
            InitializeComponent();
            List<ThingDto> things = new List<ThingDto>();
            fillThingsList();
            this.mainWindow = thingWindow;
        }

        private async void fillThingsList()
        {
            ICollection<ThingDto> things = await GetThingCollectionAPIAsync(THINGS_GET_COLLECTION);
            myDataGrid.ItemsSource = things;
        }

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

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUpdatePage();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToCreatePage();
        }
    }
}
