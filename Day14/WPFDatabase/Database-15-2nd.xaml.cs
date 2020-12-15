using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFDatabase
{
    /// <summary>
    /// Interaction logic for Database_15_2nd.xaml
    /// </summary>
    public partial class Database_15_2nd : Window
    {
        public Database_15_2nd()
        {
            InitializeComponent();
        }

        DataSet ds;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true;";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees;";


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "Emps");
            //if the connection is not opened it will open the connection and use it and then close the connection
            //it will leave it open if it was opened intially 

            cmd.CommandText = "select * from Departments;";
            da.Fill(ds, "Deps");


            //Primary Key Validation
            DataColumn[] arrCols = new DataColumn[1];
            arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
            ds.Tables["Emps"].PrimaryKey = arrCols;

            //Foreign Key Validation
            ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);

            //Column level constraints
            //ds.Tables["Deps"].Columns["DeptName"].Unique = true;

            //every data table has a default view k/a DefaultView
            //or we can use index here as well

            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView; 

            //dgEmps.ItemsSource = ds.Tables["Deps"].DefaultView;

            cn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true;";
            cn.Open();
            
            //Update Command
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.CommandText = "UpdateEmployee";

            

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn ="Name",SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            //Insert Command
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "InsertEmployee";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });

            //Delete Command
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandText = "DeleteEmployee";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;

            da.Update(ds, "Emps");
                        

            cn.Close();
        }
    }
}
