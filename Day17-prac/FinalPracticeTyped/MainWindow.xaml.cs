using FinalPracticeTyped.UserCityDataSetTableAdapters;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalPracticeTyped
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

        UserCityDataSet ds;

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            ds = new UserCityDataSet();
            UsersTableAdapter daUser = new UsersTableAdapter();
            daUser.Fill(ds.Users);

            CitiesTableAdapter daCity = new CitiesTableAdapter();
            daCity.Fill(ds.Cities);

            dgUser.ItemsSource = ds.Users.DefaultView;
            dgCity.ItemsSource = ds.Cities.DefaultView;
        
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            UsersTableAdapter daUser = new UsersTableAdapter();
            daUser.Update(ds.Users);
        }
    }
}
