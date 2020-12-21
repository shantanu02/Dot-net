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

namespace ListRightLeft
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

        private void lstLeft_Loaded(object sender, RoutedEventArgs e)
        {
            lstLeft.Items.Add("aaaaaa");
            lstLeft.Items.Add("bbbbbbb");
            lstLeft.Items.Add("cccccc");
            lstLeft.Items.Add("dddddd");
            lstLeft.Items.Add("eeeeeee");
            lstLeft.Items.Add("fffffff");
            lstLeft.Items.Add("gggggggg");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(lstLeft.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to move ");
            }
            else
            {
                List<Object> lst1 = new List<object>();

                foreach(var item in lstLeft.SelectedItems)
                {
                    lst1.Add(item);
                    lstRight.Items.Add(item);

                }
                foreach(var item in lst1)
                {
                    lstLeft.Items.Remove(item);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(lstRight.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to move");
            }
            else
            {
                List<Object> lst1 = new List<object>();
                foreach(var item in lstRight.SelectedItems)
                {
                    lst1.Add(item);
                    lstLeft.Items.Add(item);
                }
                foreach(var item in lst1)
                {
                    lstRight.Items.Remove(item);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<Object> lst1 = new List<Object>();


            foreach(var item in lstLeft.Items)
            {
                lst1.Add(item);
                lstRight.Items.Add(item);
            }
            foreach(var item in lst1)
            {
                lstLeft.Items.Remove(item);
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<Object> lst1 = new List<Object>();

            foreach(var item in lstRight.Items)
            {
                lst1.Add(item);
                lstLeft.Items.Add(item);
            }
            foreach (var item in lst1)
            {
                lstRight.Items.Remove(item);
            }

        }
    }
}
