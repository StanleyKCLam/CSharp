using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace L4Sample
{
    class Student
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public int grade { get; set; }

        private double height;
        public double Height
        {
            get { return height; }
            set
            {
                if (value >= 0 && value <= 3)
                    height = value;
                else
                {
                    MessageBox.Show("Height not correct.");
                    height = 0;
                }
            }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value >= 0 && value <= 200)
                    weight = value;
                else
                {
                    MessageBox.Show("Weight not correct.");
                    weight = 0;
                }
            }
        }

        public double BMI(double h, double w)
        {
            Height = h;
            Weight = w;
            double bmi = Weight / (Height * Height);

            return bmi;
        }

        public Student()
        {
            grade = 1;
        }

        public Student(int id, string name)
        {
            studentID = id;
            studentName = name;
            grade = 1;
        }

        public Student(int id, string name, int inputGrade)
        {
            studentID = id;
            studentName = name;
            grade = inputGrade;
        }

        public string Say()
        {
            StringBuilder strB = new StringBuilder();
            strB.AppendLine("I am " + studentName);
            strB.AppendLine("ID: " + studentID);
            strB.AppendLine("Grade: " + grade);
            return strB.ToString();
        }
    }
}
