**WhatsApp Clone (UWP)**

This project is a simple WhatsApp clone developed as a Universal Windows Platform (UWP) application. 
It simulates the core functionalities of WhatsApp, such as a contact list, chat messages, and the 
ability to send and receive messages.

**Features**

Contact List: Displays a list of contacts with their names, profile pictures, and status.
Chat Simulation: Allows users to select a contact, view previous messages, and send new messages.
Message Bubbles: Messages are displayed in bubbles, aligned to the left for received messages and to the right for sent messages.
Search Functionality: Filters contacts based on the search query.
Simulated Replies: Auto-replies are generated from the selected contact after a delay.
Read Receipts: Simulates read receipt indicators for sent messages.

**Setup**

Clone the repository to your local machine.
Open the solution in Visual Studio.
Ensure you have the required assets (e.g., profile images) in the Assets folder.
Run the project on a compatible Windows 10 device or emulator.

**Code Structure**

MainPage.xaml.cs: Contains the main logic for handling contact lists, chat messages, and search/filter functionalities.
Contact Class: Holds information about each contact, including name, profile picture, and status.

**Key Classes and Methods**

InitializeContacts: Initializes the list of contacts with pre-defined values.
PopulateContactList: Populates the contact list UI.
CreateMessageBubble: Creates a styled message bubble for each message.
SendMessage_Click: Sends a message and displays it in the chat area.
SimulateReplyFromContact: Simulates a reply from the contact after a short delay.

**Future Enhancements**

Media Attachments: Add functionality for media sharing.
Authentication: Include user authentication for a more realistic experience.
Database Integration: Persist contacts and messages with a database.
**License**

This project is for educational purposes only. WhatsApp and all its associated trademarks are owned by WhatsApp LLC. 
This project is not affiliated with or endorsed by WhatsApp LLC.
