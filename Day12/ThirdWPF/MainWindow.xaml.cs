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

namespace ThirdWPF
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

         int s = 0;
       

        private void txtNum1_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(KeyInterop.VirtualKeyFromKey(e.Key).ToString());

            if (KeyInterop.VirtualKeyFromKey(e.Key) >= 48 && KeyInterop.VirtualKeyFromKey(e.Key) <= 57)
            {
                
                    int a = int.Parse(txtNum1.Text);
                    s += a;
                    txtSum.Text = s.ToString();
            

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Numeric Values");
            }
        }

        private void txtNum2_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyInterop.VirtualKeyFromKey(e.Key) >= 48 && KeyInterop.VirtualKeyFromKey(e.Key) <= 57)
            {
              

                    int b = int.Parse(txtNum2.Text);
                    s += b;
                    txtSum.Text = s.ToString();
                
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Numeric Values");
            }
        }
    }
}
