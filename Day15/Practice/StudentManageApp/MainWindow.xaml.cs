using System;
using System.Collections.Generic;
using System.Data;
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

namespace StudentManageApp
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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=practiceDb;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand sql = new SqlCommand();
            sql.Connection = cn;
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandText = "InsertStudent";

            sql.Parameters.AddWithValue("@Name",txtName.Text);
            sql.Parameters.AddWithValue("@Email",txtEmail.Text);
            sql.Parameters.AddWithValue("@Phone",txtPhone.Text);
            sql.Parameters.AddWithValue("@DeptNo",txtDeptNo.Text);

            try
            {
                sql.ExecuteNonQuery();
                txtName.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtDeptNo.Clear();
                MessageBox.Show("Inserted");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            cn.Close();

        }

        DataSet ds;

        private void btnShowStu_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=practiceDb;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Students";


          

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "Stds");

            cmd.CommandText = "Select * from Departments";
            da.Fill(ds, "Deps");



            //DataColumn[] arrCols = new DataColumn[1];
            //arrCols[0] = ds.Tables["Stds"].Columns["StudentId"];
            //ds.Tables["Stds"].PrimaryKey = arrCols;

            ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Stds"].Columns["DeptNo"]);

            dgStudents.ItemsSource = ds.Tables["Stds"].DefaultView;


            cn.Close();
        }

        private void btnUpdateStu_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=practiceDb;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.CommandText = "UpdateStudents";

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Email", SourceColumn = "Email", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Phone", SourceColumn = "Phone", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@StudentId", SourceColumn = "StudentId", SourceVersion = DataRowVersion.Original });


            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandText = "DeleteStudent";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "StudentId", SourceColumn = "StudentId", SourceVersion = DataRowVersion.Original });

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "InsertStudent";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Email", SourceColumn = "Email", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Phone", SourceColumn = "Phone", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            //cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@StudentId", SourceColumn = "StudentId", SourceVersion = DataRowVersion.Current});



            SqlDataAdapter da = new SqlDataAdapter();
            da.DeleteCommand = cmdDelete;
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;

           
            da.Update(ds,"Stds");

           


            cn.Close();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            ds.Tables["Stds"].DefaultView.RowFilter = "DeptNo=" + txtFilter.Text;
        }
    }
}
