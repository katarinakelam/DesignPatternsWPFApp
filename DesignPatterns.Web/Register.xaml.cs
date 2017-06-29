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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        #region placeholders

            private void ShowPlaceHolder(object sender, RoutedEventArgs e)
            {

                if (username.Text == string.Empty)
                {
                    username.Text = "Enter e-mail";
                }

                if(password.Password == string.Empty)
                {
                    password.Password = "12345";
                }

                if (passwordRepeated.Password == string.Empty)
                {
                    passwordRepeated.Password = "12345";
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

                if (passwordRepeated.Password == "12345")
                {
                    passwordRepeated.Password= string.Empty;
                }
            }

        #endregion

        #region validators

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

        #endregion

        private void ValidateMatchingPasswords(object sender, RoutedEventArgs e)
        {
            if (password.Password != passwordRepeated.Password)
            {
                repeatedPasswordValidationTextBlock.Text = "Passwords not matching";
            }
            else
            {
                repeatedPasswordValidationTextBlock.Text = " ";
            }
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            string _username = username.Text;
            string _password = password.Password;
            string _passwordRepeated = passwordRepeated.Password;

            var user = new UserRegister
            {
                Username = _username,
                Password = _password,
                PasswordRepeated = _passwordRepeated
            };

            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<UserRegisterProfile>()
            );
            var mapper = new Mapper(config);
            User returnUser = mapper.DefaultContext.Mapper.Map<User>(user);

            UserService registerUserService = new UserService();

            registerUserService.RegisterUser(returnUser);

            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void Go_To_Login(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
