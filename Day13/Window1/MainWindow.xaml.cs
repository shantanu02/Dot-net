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

namespace Window1
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

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.Items.Add("Virat");
            listBox.Items.Add("Pujara");
            listBox.Items.Add("Rahane");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(listBox.Items.Count.ToString());
           
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item ");
            }
            else
            {
                MessageBox.Show(listBox.SelectedItem.ToString());
            }

            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item ");
            }
            else
            {
                MessageBox.Show(listBox.SelectedIndex.ToString());
            }

            //foreach(var itm in listBox.SelectedItems)
            //{
            //    MessageBox.Show(itm.ToString());
            //}

            //ToDo : 
            //Create 2 listbox and apply operations of removing , adding , transfering from one list to another 
            // appply also transer all between the list 
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to delete");
            }
            else
            {
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
           
        }
    }
}
