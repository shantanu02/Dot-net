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

namespace ExamFinalPracticeDatabase
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

        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();

        private void btnFil_Click(object sender, RoutedEventArgs e)
        {
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Users";

            SqlDataAdapter da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds, "users");

            dgUser.ItemsSource = ds.Tables["users"].DefaultView;

           
            cmd.CommandText = "Select * from Cities";

            da.SelectCommand = cmd;
            da.Fill(ds, "city");

            dgCity.ItemsSource = ds.Tables["city"].DefaultView;

            cn.Close();

        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = cn;
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "insert into Users values(@LoginName,@Password,@FullName,@Email,@CityId,@Phone)";

            insertCmd.Parameters.Add(new SqlParameter { ParameterName = "@LoginName", SourceColumn = "LoginName", SourceVersion = DataRowVersion.Current });
            insertCmd.Parameters.Add(new SqlParameter { ParameterName = "@Password", SourceColumn = "Password", SourceVersion = DataRowVersion.Current });
            insertCmd.Parameters.Add(new SqlParameter { ParameterName = "@FullName", SourceColumn = "FullName", SourceVersion = DataRowVersion.Current });
            insertCmd.Parameters.Add(new SqlParameter { ParameterName = "@Email", SourceColumn = "Email", SourceVersion = DataRowVersion.Current });
            insertCmd.Parameters.Add(new SqlParameter { ParameterName = "@CityId", SourceColumn = "CityId", SourceVersion = DataRowVersion.Current });
            insertCmd.Parameters.Add(new SqlParameter { ParameterName = "@Phone", SourceColumn = "Phone", SourceVersion = DataRowVersion.Current });

            SqlCommand updateCmd = new SqlCommand();
            updateCmd.Connection = cn;
            updateCmd.CommandType = CommandType.Text;
            updateCmd.CommandText = "update Users set  Password= @Password,FullName= @FullName,Email=@Email,CityId=@CityId,Phone=@Phone Where LoginName = @LoginName";

            updateCmd.Parameters.Add(new SqlParameter { ParameterName = "@LoginName", SourceColumn = "LoginName", SourceVersion = DataRowVersion.Original });
            updateCmd.Parameters.Add(new SqlParameter { ParameterName = "@Password", SourceColumn = "Password", SourceVersion = DataRowVersion.Current });
            updateCmd.Parameters.Add(new SqlParameter { ParameterName = "@FullName", SourceColumn = "FullName", SourceVersion = DataRowVersion.Current });
            updateCmd.Parameters.Add(new SqlParameter { ParameterName = "@CityId", SourceColumn = "CityId", SourceVersion = DataRowVersion.Current });
            updateCmd.Parameters.Add(new SqlParameter { ParameterName = "@Email", SourceColumn = "Email", SourceVersion = DataRowVersion.Current });
            updateCmd.Parameters.Add(new SqlParameter { ParameterName = "@Phone", SourceColumn = "Phone", SourceVersion = DataRowVersion.Current });

            SqlCommand deleteCmd = new SqlCommand();
            deleteCmd.Connection = cn;
            deleteCmd.CommandType = CommandType.Text;
            deleteCmd.CommandText = "Delete from Users where LoginName = @LoginName";

            deleteCmd.Parameters.Add(new SqlParameter { ParameterName = "@LoginName",SourceColumn="LoginName",SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();
            da.DeleteCommand = deleteCmd;
            da.InsertCommand = insertCmd;
            da.UpdateCommand = updateCmd;

            da.Update(ds, "users");
            cn.Close();
        }
    }
}
