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
using HMS.ViewModel;

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for othersettlement.xaml
    /// </summary>
    public partial class othersettlement : Page
    {
        public int error = 0;
        public othersettlement()
        {
            data.COUNT = 0;
            InitializeComponent();
            txtamt.Text = "";
            txttipamt.Text = "";
            txtremark.Text = "";
            data.COUNT = 1;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (error != 0)
            {
                pop1.IsOpen = true;
            }
            else
            {

            }
        }
    }
}
