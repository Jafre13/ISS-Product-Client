using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ISS_Client
{
    /// <summary>
    /// Interaction logic for TrainWindow.xaml
    /// </summary>
    public partial class TrainWindow : Window
    {
        string Subject { get; set; }
        string Message { get; set; }
        string Category { get; set; }
        public TrainWindow(string Subject, string Message)
        {
            InitializeComponent();
            this.Subject = Subject;
            this.Message = Message;
            train_subject.Text = Subject;
            train_message.Text = Message;
        }

        private async void send_train_button_click(object sender, RoutedEventArgs e)
        {
            Category = category_combobox.Text;
            await RestClient.getInstance().train(Message,Category);
            this.Close();
        }
    }
}
