using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Whatsapp
{
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void ForgotPassword_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Navigate to a Forgot Password page or show a dialog
            Frame.Navigate(typeof(ForgotPasswordPage));
        }

        private void SignUp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Navigate to a Sign-Up page
            Frame.Navigate(typeof(SignUpPage));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumber.Text;
            string password = Password.Password;

            // Sample hard-coded credentials for validation
            string validPhoneNumber = "1234567890";
            string validPassword = "password";

            if (phoneNumber == validPhoneNumber && password == validPassword)
            {
                // Navigate to the HomePage upon successful login
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                // Display an error message
                DisplayLoginError("Invalid phone number or password. Please try again.");
            }
        }

        private void DisplayLoginError(string message)
        {
            // Display error message in a ContentDialog
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Login Error",
                Content = message,
                CloseButtonText = "OK"
            };
            _ = errorDialog.ShowAsync();  // Asynchronously display the dialog
        }
    }
}
