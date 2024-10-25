using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media.Animation;

namespace Whatsapp
{
    public sealed partial class MainPage : Page
    {
        // List to hold all contacts
        private List<Contact> allContacts;
        private Contact currentContact;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeContacts();
        }

        // Initializes contacts with names, profile pictures, and statuses
        private void InitializeContacts()
        {
            allContacts = new List<Contact>
            {
                new Contact("NTALO WALYD", "Assets/p1.jpg", "Online"),
                new Contact("ODEKE PATRICK", "Assets/p2.jpeg", "Last seen 5 minutes ago"),
                new Contact("NIWAGABA JONATHAN", "Assets/p3.jpeg", "Typing..."),
                new Contact("NAMUBIRU ROSE", "Assets/p4.jpg", "Online"),
                new Contact("KATWITA DENIS", "Assets/p5.jpeg", "Last seen 10 minutes ago"),
                new Contact("BISASO BENJAMIN", "Assets/p6.jpg", "Last seen 1 hour ago"),
                new Contact("ANZO XAVIER ENOCK", "Assets/p7.jpg", "Online"),
                new Contact("KEMIGISHA SHAKIRA", "Assets/p8.jpeg", "Last seen yesterday"),
                new Contact("NABULYA FAITH", "Assets/p9.png", "Online"),
                new Contact("MUGISHA MICHEAL", "Assets/p10.jpg", "Online"),
                new Contact("ODONGO TIMOTHY", "Assets/p11.jpg", "Last seen 2 hours ago"),
                // Add all 50 contacts here similarly...
            };

            // Populate the contact list
            PopulateContactList(allContacts);
        }

        // Populates the contact list into the ListView
        private void PopulateContactList(List<Contact> contacts)
        {
            ContactListView.Items.Clear();
            foreach (var contact in contacts)
            {
                var item = new ListViewItem
                {
                    Padding = new Thickness(10)
                };

                // Create the contact layout with profile image, name, and status
                var contactStack = new StackPanel { Orientation = Orientation.Horizontal };

                // Profile image
                var profileImage = new Ellipse
                {
                    Width = 50,
                    Height = 50,
                    Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, contact.ProfileImage)) }
                };

                // Name and status stack
                var nameStatusStack = new StackPanel { Margin = new Thickness(10, 0, 0, 0) };

                var nameText = new TextBlock
                {
                    Text = contact.Name,
                    FontSize = 18,
                    FontWeight = Windows.UI.Text.FontWeights.Bold
                };

                var statusText = new TextBlock
                {
                    Text = contact.Status,
                    FontSize = 14,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Gray)
                };

                nameStatusStack.Children.Add(nameText);
                nameStatusStack.Children.Add(statusText);

                // Add image and name/status to stack
                contactStack.Children.Add(profileImage);
                contactStack.Children.Add(nameStatusStack);

                // Set the contact item content
                item.Content = contactStack;
                item.Tag = contact;  // Store the contact object for reference

                ContactListView.Items.Add(item);
            }
        }

        // Filters contacts based on search query
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                ClearButton.Visibility = Visibility.Visible;
                var query = SearchBox.Text.ToLower();
                var filteredContacts = allContacts.FindAll(c => c.Name.ToLower().Contains(query));
                PopulateContactList(filteredContacts);
            }
            else
            {
                ClearButton.Visibility = Visibility.Collapsed;
                PopulateContactList(allContacts);
            }
        }

        // Clears the search box and resets the contact list
        private void ClearSearch(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = string.Empty;
            PopulateContactList(allContacts);
        }

        // Updates the chat area when a contact is selected
        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactListView.SelectedItem is ListViewItem item)
            {
                currentContact = (Contact)item.Tag;
                CurrentContactName.Text = currentContact.Name;
                ChatMessagesPanel.Children.Clear(); // Clear previous chat

                // Simulate chat history (for demo purposes)
                ShowInitialMessages();
            }
        }

        // Simulate existing chat messages for the selected contact
        private void ShowInitialMessages()
        {
            var receivedMessage = CreateMessageBubble("Hello, how are you?", false);
            var sentMessage = CreateMessageBubble("I'm good, thanks!", true);

            ChatMessagesPanel.Children.Add(receivedMessage);
            ChatMessagesPanel.Children.Add(sentMessage);
        }

        // Creates a message bubble (left for received, right for sent)
        private Border CreateMessageBubble(string message, bool isSent)
        {
            var messageBorder = new Border
            {
                Background = isSent ? new SolidColorBrush(Windows.UI.Colors.LightGreen) : new SolidColorBrush(Windows.UI.Colors.White),
                Padding = new Thickness(10),
                Margin = isSent ? new Thickness(50, 10, 0, 0) : new Thickness(0, 10, 50, 0),
                CornerRadius = new CornerRadius(10),
                HorizontalAlignment = isSent ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                MaxWidth = 300
            };

            var messageText = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap
            };

            messageBorder.Child = messageText;
            return messageBorder;
        }

        // Handles sending a message and displaying it in the chat area
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (currentContact == null || string.IsNullOrWhiteSpace(MessageInputBox.Text))
                return;

            // Add the sent message to the chat
            var messageBorder = CreateMessageBubble(MessageInputBox.Text, true);
            ChatMessagesPanel.Children.Add(messageBorder);

            // Clear the input box
            MessageInputBox.Text = string.Empty;

            // Optionally simulate a reply from the contact
            SimulateReplyFromContact();
        }

        // Simulates a reply from the contact after a delay
        private async void SimulateReplyFromContact()
        {
            await System.Threading.Tasks.Task.Delay(2000); // Wait for 2 seconds
            if (currentContact != null)
            {
                var replyMessage = CreateMessageBubble("This is an automated reply!", false);
                ChatMessagesPanel.Children.Add(replyMessage);

                // Optionally add read receipt indicator
                var readReceipt = new TextBlock
                {
                    Text = "Read ✔✔",
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                    FontSize = 12,
                    Margin = new Thickness(0, 5, 10, 0),
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                ChatMessagesPanel.Children.Add(readReceipt);
            }
        }

        // Contact class to hold contact details
        public class Contact
        {
            public string Name { get; set; }
            public string ProfileImage { get; set; }
            public string Status { get; set; }

            public Contact(string name, string profileImage, string status)
            {
                Name = name;
                ProfileImage = profileImage;
                Status = status;
            }
        }

        private void AttachMedia_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
