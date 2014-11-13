using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
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
using Zanzibar.Application.RemotingServer.Service;

namespace Zanzibar.Application.RemotingServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private event Action _serverHost;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnHost.IsEnabled = false;
            _serverHost = MainWindow__serverHost;
            _serverHost.BeginInvoke(null, null);
            MessageBox.Show("Remoting server is self hosted");
         
        }

        void MainWindow__serverHost()
        {
            ChannelServices.RegisterChannel(new TcpChannel(1237), true);
            System.Runtime.Remoting.RemotingServices.Marshal(new EmployeeService(),
               "EmployeeManager");
            Console.Read();
        }
    }
}
