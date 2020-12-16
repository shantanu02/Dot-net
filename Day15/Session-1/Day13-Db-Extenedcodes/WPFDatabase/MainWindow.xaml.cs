using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;

namespace WPFDatabase
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("OKAY");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cn.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            try
            {
                cmd.ExecuteNonQuery();
               
                MessageBox.Show("OKAY");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cn.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
          

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("OKAY");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cn.Close();
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();

            SqlTransaction t = cn.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.Transaction = t;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees values(100,'new emp',12345,20)";

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;

            cmd2.Transaction = t;

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "insert into Employees values(200,'new emp2',12345,20)";


            try
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                t.Commit();
                MessageBox.Show("OKAY");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                t.Rollback();
            }
            finally
            {
                cn.Close();
            }
            
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Name from Employees";

            //ExecuteScaler will return only one single value
            //Idealy used with aggregate functions 
            MessageBox.Show(cmd.ExecuteScalar().ToString());

            
          

            cn.Close();
        }

        private void btnSelectDataReader_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees;select * from Departments;";

            SqlDataReader dr = cmd.ExecuteReader();
            

            

            //dr.Read();
            //dr[0]; -- field that we are trying to read
            //dr["EmpNo"]; -- column name can be used


            lstBox1.Items.Add("Employees --------");
            while (dr.Read())
            {
                lstBox1.Items.Add(dr["Name"]);
            }
            lstBox1.Items.Add("Departments --------");
           
            //shift the pointer to the next result set
            dr.NextResult();

            while (dr.Read())
            {
                lstBox1.Items.Add(dr["DeptName"]);
            }


            //when we open a data reader it places a exclusive lock on the connection
            //by closing the dr the lock is released
            dr.Close();



            cn.Close();
        }

        private void btnDataReader2_Click(object sender, RoutedEventArgs e)
        {

            SqlDataReader dr = GetDataReader();

            lstBox1.Items.Add("Employees --------");
            while (dr.Read())
            {
                lstBox1.Items.Add(dr["Name"]);
            }
            
            dr.Close();

        }

        //Data Access Layer
        private SqlDataReader GetDataReader()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees;";

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //as soon as the Datareader is closed it will close the connection automatically
           
            return dr;

        }

        private void btnMars_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();
            SqlCommand cmdD = new SqlCommand();
            cmdD.Connection = cn;
            cmdD.CommandType = CommandType.Text;
            cmdD.CommandText = "select * from Departments;";

            SqlCommand cmdE = new SqlCommand();
            cmdE.Connection = cn;
            cmdE.CommandType = CommandType.Text;

            SqlDataReader drD = cmdD.ExecuteReader();

            while (drD.Read())
            {
                lstBox1.Items.Add(drD["DeptName"]);

                cmdE.CommandText = "select * from Employees where DeptNo = " + drD["DeptNo"];
                SqlDataReader drE = cmdE.ExecuteReader();

                while (drE.Read())
                {
                    lstBox1.Items.Add("     -" + drE["Name"]);
                }
                drE.Close();

            }

            drD.Close();

            cn.Close();
        }
    }
    
}
