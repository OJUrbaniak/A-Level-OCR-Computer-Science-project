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

namespace computingProject
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

        private void startupButton_Click(object sender, RoutedEventArgs e)
        {
            startupCostCalc win1 = new startupCostCalc();   //Defines a new window
            win1.Show();                                    //Shows the startup cost window
        }

        private void conversionButton_Click(object sender, RoutedEventArgs e)
        {
            conversionRateCalc win2 = new conversionRateCalc();   //Defines a new window
            win2.Show();                                          //Shows the previously defined window
        }

        private void breakevenButton_Click(object sender, RoutedEventArgs e)
        {
            breakevenPointCalc win3 = new breakevenPointCalc();   //Defines a new window
            win3.Show();                                          //Shows the previously defined window
        }
    }
}
