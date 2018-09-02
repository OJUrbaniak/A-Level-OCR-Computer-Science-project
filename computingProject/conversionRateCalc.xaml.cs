using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml;
using System.Xml.Linq;

namespace computingProject
{
    /// <summary>
    /// Interaction logic for conversionRateCalc.xaml
    /// </summary>
    public partial class conversionRateCalc : Window
    {
        public conversionRateCalc()
        {
            InitializeComponent();
            XmlDocument xmlDoc = new XmlDocument();
            // Loads .xml into memory
            xmlDoc.Load("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            // For each "node" (element) in childnodes
            // Adds the missing "EUR" (Euro) currency to the list of currencies along with it's value, and as the exchange rates are based on the euro being valued at 1 I set currencyVal to 1
            currencyList.itemList.Add(new item { currencyName = "EUR", currencyVal = 1 });
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {
                // Creates a "name" variable from the "currency" attribute in the document
                string name = (xmlNode.Attributes["currency"].Value);
                // Creates a "val" variable from the "rate" attribute in the document
                decimal val = Convert.ToDecimal((xmlNode.Attributes["rate"].Value));
                // Adds a new item to itemList (containing all currencies) using the previously set "name" and "val" attributes
                currencyList.itemList.Add(new item { currencyName = name, currencyVal = val });
            }
            // Creates an integer variable called “i” for index and sets it to 0
            int i = 0;
            
            //fromCurrency.Items.Add("EUR");
            //toCurrency.Items.Add("EUR");
            // Taken from previous module, for each item in the itemList it will do what’s in between the brackets
            foreach (item currency in currencyList.itemList)
            {
                // Adds item with index "i" to comboBoxes
                fromCurrency.Items.Add(currencyList.itemList[i].currencyName); 
                toCurrency.Items.Add(currencyList.itemList[i].currencyName); 
                // Increments the index
                i++;
            }
            
        }

        public class currencyList
        {
            // Creates list of startupItems
            public static List<item> itemList = new List<item>();
        }

        public class item
        {
            // Property "Name" of the type string
            public string currencyName { get; set; }
            // Property "Cost" of the type decimal
            public decimal currencyVal { get; set; }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (item currency in currencyList.itemList)
            {
                // Adds a new line and the item’s “currencyName”, a space, and it’s “currencyVal”
                textBox.Text = textBox.Text + "\n" + currencyList.itemList[i].currencyName + " " + currencyList.itemList[i].currencyVal;
                // Increments the index                
                i++;
            }
        }

        private void fromBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultButton_Click(sender, e);    
        }

        private void resultButton_Click(object sender, RoutedEventArgs e)
        {
            double parsedValue;
            if (fromBox.Text != null && !string.IsNullOrWhiteSpace(fromBox.Text) && fromCurrency.SelectedIndex != -1 && toCurrency.SelectedIndex != -1 && double.TryParse(fromBox.Text, out parsedValue)) {
                // Creates a decimal variable "fromVal" and sets it's value to the converted value of fromBox
                decimal fromVal = Convert.ToDecimal(fromBox.Text);
                // Creates an int variable and iterates through the list trying to find the currency selected by the user in the "toCurrency" comboBox
                int selectedItem = currencyList.itemList.FindIndex(x => x.currencyName == toCurrency.Text);
                // Creates an int variable and iterates through the list trying to find the currency selected by the user in the "fromCurrency" comboBox
                int conversionItem = currencyList.itemList.FindIndex(x => x.currencyName == fromCurrency.Text);
                // Sets the "toBox" textBox text to the value the user entered in "fromBox" multiplied by the currencyVal property of the selectedItem (the item found earlier)
                toBox.Text = Convert.ToString((fromVal / currencyList.itemList[conversionItem].currencyVal) * currencyList.itemList[selectedItem].currencyVal);
            }
            else { MessageBox.Show("Two currencies need to be chosen and a numerical value input into the first textbox."); }
        }

        private void ListCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Height = 322;
        }

        private void ListCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Height = 170;
        }
    }
}