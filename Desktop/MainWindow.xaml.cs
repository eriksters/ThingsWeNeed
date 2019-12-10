using Desktop.Models;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnApi_Click(object sender, RoutedEventArgs e)
        {
            Thing thing = await GetAPIAsync("https://localhost:44371/api/Things/1");

            String sResult = "API Result on /api/Things/1: " + Environment.NewLine + "Name=" + thing.Name + Environment.NewLine + "Id=" + thing.Id;

            //MessageBox.Show(sResult, "API Read");

            tbxApi.Text = sResult;
        }

        static async Task<Thing> GetAPIAsync(string path)
        {
            string responseBody = "";
            Thing thing = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                thing = JsonConvert.DeserializeObject<Thing>(responseBody);
            }

            return thing;
        }
    }
}
