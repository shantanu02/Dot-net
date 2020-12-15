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

namespace WpfApp1
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

        private void lst1_Loaded(object sender, RoutedEventArgs e)
        {
            lst1.Items.Add("Development");
            lst1.Items.Add("Database");
            lst1.Items.Add("Networking");
            lst1.Items.Add("Testing");
            lst1.Items.Add("Technical Support");
            
        }

        private void btnmovleftone_Click(object sender, RoutedEventArgs e)
        {
            if(lst1.SelectedItem == null)
            {
                MessageBox.Show("No items selected... Please select the items to move !");
            }
            else
            {
               List<Object> lst1cpy = new List<object>();



                foreach (var itm in lst1.SelectedItems)
                {
                   lst1cpy.Add(itm);
                   lst2.Items.Add(itm);

                }

                foreach(var itm in lst1cpy)
                {
                    lst1.Items.Remove(itm);
                }

               

            }
        }

        private void btnmovleftall_Click(object sender, RoutedEventArgs e)
        {
            List<Object> lst1cpy = new List<object>();



            foreach (var itm in lst1.Items)
            {
                lst1cpy.Add(itm);
                lst2.Items.Add(itm);

            }

            foreach (var itm in lst1cpy)
            {
                lst1.Items.Remove(itm);
            }

        }

        private void btnmovrightone_Click(object sender, RoutedEventArgs e)
        {
            if (lst2.SelectedItem == null)
            {
                MessageBox.Show("No items selected... Please select the items to move !");
            }
            else
            {
                List<Object> lst1cpy = new List<object>();



                foreach (var itm in lst2.SelectedItems)
                {
                    lst1cpy.Add(itm);
                    lst1.Items.Add(itm);

                }

                foreach (var itm in lst1cpy)
                {
                    lst2.Items.Remove(itm);
                }

            }
        }

        private void btnmovrightall_Click(object sender, RoutedEventArgs e)
        {
            List<Object> lst1cpy = new List<object>();



            foreach (var itm in lst2.Items)
            {
                lst1cpy.Add(itm);
                lst1.Items.Add(itm);

            }

            foreach (var itm in lst1cpy)
            {
                lst2.Items.Remove(itm);
            }
        }
    }
}
