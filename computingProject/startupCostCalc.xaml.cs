using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace computingProject
{
    /// <summary>
    /// Interaction logic for startupCostCalc.xaml
    /// </summary>
    public partial class startupCostCalc : Window
    {
        public startupCostCalc()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            decimal parsedValue;
            if ((decimal.TryParse(costBox.Text, out parsedValue)&& costNameBox.Text != null && !string.IsNullOrWhiteSpace(costNameBox.Text) && !string.IsNullOrWhiteSpace(costBox.Text) && costNameBox.Text.Length < 20)&&(Convert.ToDouble(costBox.Text) < Double.MaxValue))
            {
                // Populate the DataView with the content of costNameBox and costBox
                costGrid.Items.Add(new startupItem { Name = costNameBox.Text, Cost = Decimal.Parse(costBox.Text) });
                // Adds to the list "itemList" of startupItems
                itemList.Add(new startupItem { Name = costNameBox.Text, Cost = Decimal.Parse(costBox.Text) });
            }
            else { MessageBox.Show("Cost name can't be empty or formed entirely of whitespace and has to be under 20 characters long."); }
        }

        public void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            // Copies the .SelectedItems collection to a variable
            var selected = costGrid.SelectedItems.Cast<startupItem>().ToArray();
            // Iterates through each item in the "selected" array
            foreach (var item in selected)
            {
                //Removes item from itemList and costGrid
                itemList.Remove(item);
                costGrid.Items.Remove(item);
            }
        }

        private void resultButton_Click(object sender, RoutedEventArgs e)
        {
            // Creates a decimal and sets it to 0
            decimal result = 0;
            // FOR loop, loops through each item in the itemList
            foreach (startupItem item in itemList) {
                //Adds the "Cost" property from each item in itemList to result
                result = result + item.Cost;
            }
            // Outputs result to textbox after converting to string
            resultBox.Text = Convert.ToString(result);
        }

        public class startupItem
        {
            // Property "Name" of the type string
            public string Name { get; set; }
            // Property "Cost" of the type decimal
            public decimal Cost { get; set; }           
        }

        // Creates list of startupItems
        public static List<startupItem> itemList = new List<startupItem>();
    }
    // INPUT VALIDATION
    public class NotEmpty : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //throw new NotImplementedException();
            //var str = value as string;
            var str = value.ToString();

            if (str == null||str=="")
            {
                return new ValidationResult(false, "Please enter some text");
                throw new Exception("Cannot be null or empty");
            }
            return new ValidationResult(true, null);
        }
    }
}
