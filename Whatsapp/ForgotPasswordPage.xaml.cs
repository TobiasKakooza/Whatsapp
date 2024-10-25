using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Whatsapp
{
    public sealed partial class ForgotPasswordPage : Page
    {
        public ForgotPasswordPage()
        {
            this.InitializeComponent();
        }

        private void SendCodeButton_Click(object sender, RoutedEventArgs e)
        {
            string contactInfo = RecoveryContact.Text;

            if (string.IsNullOrEmpty(contactInfo))
            {
                DisplayMessage("Please enter your phone number or email.");
                return;
            }

            // Here you would typically send a recovery code via SMS or email
            // For this example, we'll just display a message
            DisplayMessage("A recovery code has been sent to your contact information.");
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
                Title = "Forgot Password",
                Content = message,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
