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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersPage : Page
    {

        static readonly string USERS_GET_COLLECTION = "https://localhost:44371/api/Users";
        static HttpClient client = new HttpClient();
        static TwnContext twnContext = new TwnContext();
        MainWindow mainWindow;
        public UsersPage(MainWindow userWindow)
        {
            InitializeComponent();
            List<UserDto> things = new List<UserDto>();
            fillUsersList();
            this.mainWindow = userWindow;
        }
        private async void fillUsersList()
        {
            ICollection<UserDto> users = await GetUserCollectionAPIAsync(USERS_GET_COLLECTION);
            myDataGrid.ItemsSource = users;
        }
        static async Task<ICollection<UserDto>> GetUserCollectionAPIAsync(string path)
        {
            string responseBody = "";
            ICollection<UserDto> usersResponse = new List<UserDto>();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                usersResponse = JsonConvert.DeserializeObject<ICollection<UserDto>>(responseBody);
            }

            return usersResponse;
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToCreatePage();
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUpdatePage();
        }

    }
}
