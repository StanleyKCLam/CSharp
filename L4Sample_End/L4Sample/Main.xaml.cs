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

namespace L4Sample
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        List<SalesPerson> SalesPersons = new List<SalesPerson>();
        string userName, dept;

        public Main()
        {
            InitializeComponent();
            DefaultSalesList();
        }

        private int qty;
        public int Qty
        {
            get { return qty; }
            set
            {
                if (value >= 0 && value <= 99)
                { qty = value; }
                else
                {
                    MessageBox.Show("Quantity not correct...");
                    qty = 0;                    
                }
            }
        }

        public class SalesPerson
        {
            public int salesID { get; set; }
            public string userName { get; set; }
            public string dept { get; set; }
        }

        private void DefaultSalesList()
        {
            SalesPerson s1 = new SalesPerson();
            s1.salesID = 10001;
            s1.userName = "Eric";
            s1.dept = "IT";

            SalesPerson s2 = new SalesPerson();
            s2.salesID = 10002;
            s2.userName = "David";
            s2.dept = "Sales";

            SalesPerson s3 = new SalesPerson();
            s3.salesID = 10003;
            s3.userName = "Benny";
            s3.dept = "Others";

            SalesPersons.Add(s1);
            SalesPersons.Add(s2);
            SalesPersons.Add(s3);

            foreach (SalesPerson sp in SalesPersons)
            {
                cbxSalesID.Items.Add(sp.salesID);
            }
        }

        private void cbxSalesID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userName = SalesPersons[cbxSalesID.SelectedIndex].userName.ToString();
            dept = SalesPersons[cbxSalesID.SelectedIndex].dept.ToString();

            lblSalesInfo.Content = "User: " + userName + " - Dept: " + dept;
        }

        public enum Grade
        {
            XL = 5,
            L = 4,
            M = 3,
            S = 2,
            XS = 1,
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            Students stu = new L4Sample.Students();
            stu.ShowDialog();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string items = ((ComboBoxItem)cbxItems.SelectedItem).Content.ToString();

                Grade enumGrade = (Grade)Enum.Parse(typeof(Grade), txtGrade.Text);
                int gradeValue = (int)enumGrade;
                string gradeStr = enumGrade.ToString();

                Qty = int.Parse(txtQTY.Text);

                StringBuilder strMsg = new StringBuilder();
                strMsg.AppendLine("Sales Person: " + userName);
                strMsg.AppendLine("Department: " + dept);
                strMsg.AppendLine("");
                strMsg.AppendLine("Items: " + items);
                strMsg.AppendLine("Grade: " + gradeValue + " (" + gradeStr + ")");
                strMsg.AppendLine("Quantity: " + Qty);

                MessageBox.Show(strMsg.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Value cannot be null.");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please enter vaild Grade.");               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
