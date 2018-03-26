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

namespace L4Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnLogin_Click(null, null);
        }

        private bool Login(string _username, int _pw)
        {
            if (_username == "test" && _pw == 123456)
                return true;
            else
                return false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login(txtUsername.Text, int.Parse(txtPassword.Password)))
                {
                    Main _main = new L4Sample.Main();
                    this.Hide();
                    _main.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Login fail...");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format not correct.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
