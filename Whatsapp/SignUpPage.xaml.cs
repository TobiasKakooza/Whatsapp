using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Whatsapp
{
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string phoneNumber = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            // Basic input validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                DisplayMessage("All fields are required. Please fill in all information.");
                return;
            }

            // Normally, here you would save the user details to a database or send it to a backend service.
            // For this example, we'll display a success message
            DisplayMessage("Account created successfully! You can now log in.");
        }

        private void BackToLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Navigate back to the Login page
            Frame.Navigate(typeof(Login));
        }

        private async void DisplayMessage(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Sign Up",
                Content = message,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
