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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserRegistration.Engine;

namespace UserRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
           Engine.RegUser_engine service = new Engine.RegUser_engine();

            try
            {
                string name = service.Auth(InLogin.Text, InPassword.Text);
                MessageBox.Show("Добро пожаловать, "+ name+"!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Window registration = new RegistrationWindow();
            registration.Show();
        }
    }
}
