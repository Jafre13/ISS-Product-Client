using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISS_Client
{
    public partial class MainWindow : Window
    {
        //define Variables
        //MyMessages = all messages in system
        //StateMessages = Messages for Current State
        //State = current State
        private ObservableCollection<Message> MyMessages { get; set; }
        private ObservableCollection<Message> StateMessages { get; set; }
        private string State { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MyMessages = new ObservableCollection<Message>();
            StateMessages = new ObservableCollection<Message>(MyMessages.ToArray());
            State = "all";
            
            //Set datagrid to listen to StateMessages
            grid.ItemsSource = StateMessages;
        }



        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {

            //Pull Text From TextBoxes
            string text = textBox.Text;
            string subject = subject_box.Text;
            //Call Restclient and async wait response
            Message m = await RestClient.getInstance().getClassification(subject,text);

            //Add message to all message on update datagrid
            MyMessages.Add(m);
            updateMessages();
        }

        private void updateMessages()
        {

            //Clear StateMessages
            StateMessages = new ObservableCollection<Message>();

            //Populate state messages for current state
            foreach (var m in MyMessages)
            {
                if (m.category == State)
                {
                    StateMessages.Add(m);
                }
                else if (State == "all"){
                    StateMessages = new ObservableCollection<Message>(MyMessages.ToArray());
                }
                

            }
            grid.ItemsSource = StateMessages;
        }

        private void ChangeStateWorkClick(object sender, RoutedEventArgs e)
        {
            State = "work";
            updateMessages();
            

        }

        private void ChangeStateUrgentClick(object sender, RoutedEventArgs e)
        {
            State = "urgent";
            updateMessages();

        }
        private void ChangeStateMeetingClick(object sender, RoutedEventArgs e)
        {
            State = "meeting";
            updateMessages();
        }

            private void ChangeStateContractClick(object sender, RoutedEventArgs e)
        {
            State = "contract";
            updateMessages();

        }
        private void ChangeStateSpamClick(object sender, RoutedEventArgs e)
        {
            State = "spam";
            updateMessages();

        }


        private void ChangeStateAllClick(object sender, RoutedEventArgs e)
        {
            State = "all";
            StateMessages = new ObservableCollection<Message>(MyMessages.ToArray());
            grid.ItemsSource = StateMessages;

        }

        private void ReTrainClick(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            string message = StateMessages[index].Text;
            string subject = StateMessages[index].Subject;
            TrainWindow TrainWindow = new TrainWindow(subject, message);
            TrainWindow.Show();
        }

        private async void DbTest(object sender, RoutedEventArgs e)
        {
            List<string> SpamResults = DBConnector.getInstance().TrainSpam();
            List<string> WorkResults=  DBConnector.getInstance().TrainWork();
            List<string> UrgentResults =  DBConnector.getInstance().TrainUrgent();
            List<string> MeetingResults =  DBConnector.getInstance().TrainMeeting();
            List<string> ContractResults =  DBConnector.getInstance().TrainContract();

            Console.WriteLine("SPAM" + SpamResults.Count);
            Console.WriteLine("WORK" + WorkResults.Count);
            Console.WriteLine("URGENT" + UrgentResults.Count);
            Console.WriteLine("MEETING" + MeetingResults.Count);
            Console.WriteLine("CONTRACT" + ContractResults.Count);
            foreach (string s in SpamResults)
            {
                await RestClient.getInstance().train(s, "spam");
            }
            foreach (string s in WorkResults)
            {
                await RestClient.getInstance().train(s, "work");
            }
            foreach (string s in UrgentResults)
            {
                await RestClient.getInstance().train(s, "urgent");
            }
            foreach (string s in MeetingResults)
            {
                await RestClient.getInstance().train(s, "meeting");
            }
            foreach (string s in ContractResults)
            {
                await RestClient.getInstance().train(s, "contract");
            }

        }
    }
    
}
