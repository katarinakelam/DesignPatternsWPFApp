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

namespace DesignPatternsWeb
{
    /// <summary>
    /// Interaction logic for MyProfile.xaml
    /// </summary>
    public partial class MyProfile : Window
    {
        public string Username { get; set; }

        public MyProfile()
        {
            InitializeComponent();
        }

        public void ShowWelcomeMessage(object sender, RoutedEventArgs e)
        {
            welcomeMessage.Text = "Welcome "  + Username + "!";
        }

        public void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
