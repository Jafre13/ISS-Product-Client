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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Message> MyMessages { get; set; }
        private ObservableCollection<Message> StateMessages { get; set; }
// ivate RestClient client { get; }


        public MainWindow()
        {
            InitializeComponent();
// client = new RestClient();
            MyMessages = new ObservableCollection<Message>();
            StateMessages = new ObservableCollection<Message>(MyMessages.ToArray());
            //grid.ItemsSource = MyMessages;

            MyMessages.Add(new Message("meeh", new List<bool>(new bool[] { true,false,false,false})));
            MyMessages.Add(new Message("meeh1", new List<bool>(new bool[] { false, true,true,false})));
            MyMessages.Add(new Message("meeh2", new List<bool>(new bool[] { true,false,true,true })));
            Console.WriteLine(MyMessages.Count);
            StateMessages = new ObservableCollection<Message>(MyMessages.ToArray());
            grid.ItemsSource = StateMessages;
        }



        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            Message m = new Message(textBox.Text, new List<bool>());
            MyMessages.Add(m);
            RestClient.getClassification(m.Text);
            updateMessages();
        }

        private void updateMessages()
        {
            foreach (Message m in MyMessages)
            {
               // Console.WriteLine("" + m.Created.ToString());
            }
        }

        private void ChangeStateWorkClick(object sender, RoutedEventArgs e)
        {
            StateMessages.Clear();
            Console.WriteLine(MyMessages.Count);
            foreach (var m in MyMessages)
            {
                Console.WriteLine("Classes" + m.Classes);
                if (m.Classes[0] == true)
                {
                    Console.WriteLine("Found Work");
                    StateMessages.Add(m);
                }
                
            }
            Console.WriteLine(StateMessages.Count);

            grid.ItemsSource = StateMessages;

        }

        private void ChangeStatePersonalClick(object sender, RoutedEventArgs e)
        {
            StateMessages = new ObservableCollection<Message>();
            Console.WriteLine("ButtonClick");
            foreach (var m in MyMessages)
            {
                if (m.Classes[1] == true)
                {
                    Console.WriteLine("Found Personal");
                    StateMessages.Add(m);
                }

            }
            Console.WriteLine(StateMessages.Count);
            grid.ItemsSource = StateMessages;

        }

        private void ChangeStateAllClick(object sender, RoutedEventArgs e)
        {
            StateMessages = new ObservableCollection<Message>(MyMessages.ToArray());
            grid.ItemsSource = StateMessages;

        }

    }
    
}
