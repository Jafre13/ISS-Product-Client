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

        private void ChangeStatePersonalClick(object sender, RoutedEventArgs e)
        {
            State = "personal";
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
    }
    
}
