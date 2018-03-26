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
using System.Windows.Shapes;
using System.Data.OleDb;

namespace DatabaseSample
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SampleDB.accdb;");

        public Register()
        {
            InitializeComponent();
        }

        private void CreateMember(string userName, string password)
        {
            OleDbCommand cmdRegister = new OleDbCommand(
                "INSERT INTO [MemberAccessException] (userName], [Password]) VALUES (@userName, @pw)", Conn);
            cmdRegister.Parameters.AddWithValue("@userName", userName);
            cmdRegister.Parameters.AddWithValue("@pw", password);
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            cmdRegister.ExecuteNonQuery();
            if (Conn.State == ConnectionState.Open) { Conn.Close(); }
            cmdRegister.Dispose();
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            CreateMember(txtUserName.Text, txtPassword.Text);
            MessageBox.Show(txtUserName.Text + " register successful.");
            this.Close();
        }
    }
}
