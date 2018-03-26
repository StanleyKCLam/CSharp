using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login(txtUsername.Text, int.Parse(txtPassword.Text)))
                {
                    Main main = new Main();
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Login Fail.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error.");
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

        private bool Login(string name, int pw)
        {
            if (name == "stanley" && pw == 123456)
                return true;
            else
                return false;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
