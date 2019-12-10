using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GoToThingPage();
        }

        public void GoToThingPage()
        {
            ThingPage newPage = new ThingPage(this);
            Content = newPage;
        }

        public void GoToUpdatePage()
        {
            ThingUpdatePage newPage = new ThingUpdatePage(this);
            Content = newPage;
        }

        public void GoToCreatePage()
        {
            ThingCreatePage newPage = new ThingCreatePage(this);
            Content = newPage;
        }

        private void BtnClickUsers(object sender, RoutedEventArgs e)
        {
            Main.Content = new Users();
        }

        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
