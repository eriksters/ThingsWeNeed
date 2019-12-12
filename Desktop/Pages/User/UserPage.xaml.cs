using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.RestInterface.Rest;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        UserRest userRest;
        MainWindow mainWindow;

        public UserPage(MainWindow userWindow)
        {
            if (userRest == null)
            {
                userRest = new UserRest();
            }

            InitializeComponent();
            List<ThingDto> users = new List<ThingDto>();
            fillUsersList();
            this.mainWindow = userWindow;
        }
        private  void fillUsersList()
        {
            ICollection<UserDto> users = userRest.GetCollection();
            myDataGrid.ItemsSource = users;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

            //UserDto user = (UserDto)myDataGrid.SelectedItem;
            //userRest.Delete(user.UserId);
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserCreatePage();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDto user = (UserDto)myDataGrid.SelectedItem;
            //mainWindow.GoToUserUpdatePage(user.UserId);
        }

        private void householdBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void usersNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserPage();
        }

        private void householdsNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHouseholdPage();
        }

        private void thingsNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingPage();
        }
    }
}
