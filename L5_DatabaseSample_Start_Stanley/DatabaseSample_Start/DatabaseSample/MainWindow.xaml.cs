using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace DatabaseSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection Conn = new OleDbConnection(
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SampleDB.accdb;");
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.ShowDialog();
            this.Show();
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private bool Login(string userName, string password)
        {
            OleDbCommand cmdLogin = new OleDbCommand(
                "SELECT [UserName] FROM [Member] WHERE [UserName] = @userName AND [Password] = @pw", Conn);
            cmdLogin.Parameters.AddWithValue("@userName", userName);
            cmdLogin.Parameters.AddWithValue("@pw", password);
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            string loginSuccess = (string)cmdLogin.ExecuteScalar();
            if (Conn.State == ConnectionState.Open) { Conn.Close(); }
            cmdLogin.Dispose();

            if (loginSuccess != null)
                return true;
            else
                return false;
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Login(txtUserName.Text, txtPassword.Password))
            {
                Main main = new Main();
                this.Hide();
                main.ShowDialog();
                this.Show();
                txtPassword.Clear();
                txtPassword.Focus();
            }
            else
            {
                MessageBox.Show("Bad username or password.");
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
            }
        }
    }
}
