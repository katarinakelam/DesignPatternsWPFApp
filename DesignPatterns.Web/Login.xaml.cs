using AutoMapper;
using DesignPatternsWeb.AutoMapper.Profiles;
using DesignPatternsWeb.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Carbon.Data.Annotations;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsBusinessLogic.BusinessServices;

namespace DesignPatternsWeb
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        #region placeholder

        private void ShowPlaceHolder(object sender, RoutedEventArgs e)
        {

            if (username.Text == string.Empty)
            {
                username.Text = "Enter e-mail";
            }

            if (password.Password == string.Empty)
            {
                password.Password = "12345";
            }
        }

        private void HidePlaceHolder(object sender, RoutedEventArgs e)
        {
            if (username.Text == "Enter e-mail")
            {
                username.Text = string.Empty;
            }

            if (password.Password == "12345")
            {
                password.Password = string.Empty;
            }
        }

        #endregion

        private void ValidateEmail(object sender, RoutedEventArgs e)
    {
        if (!new EmailAddressAttribute().IsValid(username.Text))
        {
            emailValidationTextBlock.Text = "E-mail format is not valid";
        }

        else
        {
            emailValidationTextBlock.Text = " ";
        }
    }

    private void ValidatePasswordLength(object sender, RoutedEventArgs e)
    {
        if (password.Password.Length < 6)
        {
            passwordLengthValidationTextBlock.Text = "Password too short";
        }
        else
        {
            passwordLengthValidationTextBlock.Text = " ";
        }

    }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string _username = username.Text;
            string _password = password.Password;

            var user = new UserLogin
            {
                Username = _username,
                Password = _password
            };

            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<UserLoginProfile>()
            );
            var mapper = new Mapper(config);
            User returnUser = mapper.DefaultContext.Mapper.Map<User>(user);

            UserService loginUserService = new UserService();

            string returnMessage = loginUserService.LoginUser(returnUser);
            // bool

            if (returnMessage == "OK")
            {
                Register register = new Register();
                this.Hide();
                register.Show();
            }
            else
            {
                returnMessage = "Korisničko ime ili lozinka nisu valjani";
            }
           
        }
    }
}
