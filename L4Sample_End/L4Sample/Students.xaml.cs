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
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        public Students()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            //Student s1 = new Student();
            //s1.studentName = "Andy";
            //s1.studentID = 10001;
            ////s1.grade = 1;

            //Student s2 = new Student();
            //s2.studentName = "Brian";
            //s2.studentID = 10002;
            ////s2.grade = 1;

            Student s1 = new Student(10001, "Andy");
            Student s2 = new Student(10002, "Brian", 2);
            s2.Height = 1.7;
            s2.Weight = 56;
            Student s3 = new Student(10003, "Candy");

            MessageBox.Show(s1.Say());
            MessageBox.Show(s1.BMI(1.7, 60).ToString());
            MessageBox.Show(s2.Say());
            MessageBox.Show(s2.BMI(s2.Height,s2.Weight).ToString());
            MessageBox.Show(s3.Say());

        }
    }
}
