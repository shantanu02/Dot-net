using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using WPFDatabase.MyDataSetTableAdapters;

namespace WPFDatabase
{
    /// <summary>
    /// Interaction logic for TypedDataSet.xaml
    /// </summary>
    public partial class TypedDataSet : Window
    {
        public TypedDataSet()
        {
            InitializeComponent();
        }

        MyDataSet ds;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ds = new MyDataSet();
            DepartmentsTableAdapter daDeps = new DepartmentsTableAdapter();

            daDeps.Fill(ds.Departments);

            EmployeesTableAdapter daEmps = new EmployeesTableAdapter();

            daEmps.Fill(ds.Employees);

            dgEmps.ItemsSource = ds.Employees.DefaultView;
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeesTableAdapter daEmps = new EmployeesTableAdapter();
            daEmps.Update(ds.Employees);
        }
    }
}
