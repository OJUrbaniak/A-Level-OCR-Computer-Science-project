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
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Data;

namespace computingProject
{
    /// <summary>
    /// Interaction logic for breakevenPointCalculator.xaml
    /// </summary>
    public partial class breakevenPointCalc : Window
    {

        public breakevenPointCalc()
        {
            InitializeComponent();
            pricePerUnitBox.TextChanged += pricePerUnitBox_TextChanged;
            variableCostPerUnitBox.TextChanged += variableCostPerUnitBox_TextChanged;
        }

        private void copyCostsButton_Click(object sender, RoutedEventArgs e)
        {
            // Creates integer i variable and sets it to 0
            int i = 0;
            // Iterates through each item in the startupItemList.itemList, the list behind the datagrid on the Startup Calculator module
            foreach (startupCostCalc.startupItem item in startupCostCalc.itemList)
            {
                // Copies the item with index i to Breakeven Calculator costGrid
                costGrid.Items.Add(startupCostCalc.itemList[i]);
                // Adds a new item to the itemList with the Name and Cost values of item in itemList with index i
                itemList.Add(new listItem { Name = startupCostCalc.itemList[i].Name, Cost = startupCostCalc.itemList[i].Cost });
                // Adds 1 to index
                i++;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            double parsedValue;
            if ((costNameBox.Text != null && !string.IsNullOrWhiteSpace(costNameBox.Text) && !string.IsNullOrWhiteSpace(costBox.Text) && costNameBox.Text.Length < 20) && double.TryParse(costBox.Text, out parsedValue))
            {
                // Populate the DataView with the content of costNameBox and costBox
                costGrid.Items.Add(new listItem { Name = costNameBox.Text, Cost = Decimal.Parse(costBox.Text) });
                // Adds to the list "itemList" of listItems
                itemList.Add(new listItem { Name = costNameBox.Text, Cost = Decimal.Parse(costBox.Text) });
            }
            else { MessageBox.Show("Cost name can't be empty or formed entirely of whitespace and has to be under 20 characters long."); }
        }

        // Creates list of listItems
        public static List<listItem> itemList = new List<listItem>();

        // Class, defines the properties of listItem
        public class listItem
        {
            // Property "Name" of the type string
            public string Name { get; set; }
            // Property "Cost" of the type decimal
            public decimal Cost { get; set; }
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            // Copies the .SelectedItems collection to a variable
            var selected = costGrid.SelectedItems.Cast<listItem>().ToArray(); //FIx
            // Iterates through each item in the "selected" array
            foreach (var item in selected)
            {
                //Removes item from itemList and costGrid
                itemList.Remove(item);
                costGrid.Items.Remove(item);
            }
            //Invalidate plot data
            //Graph.InvalidatePlot(true);
        }
                
        private void calculateBreakeven(object sender, RoutedEventArgs e) {
            decimal parsedValue;
            if (decimal.TryParse(pricePerUnitBox.Text, out parsedValue) && decimal.TryParse(variableCostPerUnitBox.Text, out parsedValue) && (calculateFixedCosts(itemList) >= 0))
            {
                resultBox.Text = Convert.ToString(calculateBreakevenPoint(calculateFixedCosts(itemList), Convert.ToDecimal(pricePerUnitBox.Text), Convert.ToDecimal(variableCostPerUnitBox.Text)));
            }
            else { MessageBox.Show("Only numbers allowed here"); }
        }       

        private decimal calculateFixedCosts(List<listItem> list)
        {
            // Creates a decimal and sets it to 0
            decimal fixedCosts = 0;
            // FOR loop, loops through each item in the itemList
            foreach (listItem item in itemList)
            {
                //Adds the "Cost" property from each item in itemList to result
                fixedCosts = fixedCosts + item.Cost;
            }
            // Outputs result to textbox after converting to string
            return fixedCosts;
        }

        public decimal calculateBreakevenPoint(decimal fixedCosts, decimal salesPrice, decimal variableCost) {
            if (((salesPrice - variableCost)) > 0)
            {
                decimal result = fixedCosts / (salesPrice - variableCost);
                return result;
            }
            else { decimal result = 0; return result; }            
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            calculateBreakeven(sender, e);
            float parsedValue;
            if ( float.TryParse(pricePerUnitBox.Text, out parsedValue) && float.TryParse(variableCostPerUnitBox.Text, out parsedValue))
            {
                //float.TryParse(unitNumBox.Text, out parsedValue) &&
                float numofUnits = 0;
                if (unitNumBox.Text == null||string.IsNullOrWhiteSpace(unitNumBox.Text)) {numofUnits = float.Parse(resultBox.Text) * 2; }
                else {
                    if (float.TryParse(unitNumBox.Text, out parsedValue))
                    {
                        numofUnits = float.Parse(unitNumBox.Text);
                    }
                    else { MessageBox.Show("Number of units must be a number."); }
                }
                                               
                float salesPricePerUnit = float.Parse(pricePerUnitBox.Text);
                float variableCostPerUnit = float.Parse(variableCostPerUnitBox.Text);
                float fixedCosts = (float)(calculateFixedCosts(itemList));
                
                float totalRevenue = numofUnits * salesPricePerUnit;
                float totalCosts = (numofUnits * variableCostPerUnit) + fixedCosts;

                float intersectingPointX = getIntersectingPointX(numofUnits, totalRevenue, fixedCosts, numofUnits, totalCosts);

                var tRevenue = new OxyPlot.Series.LineSeries() { }; //tRevenue = Total revenue
                var tCosts = new OxyPlot.Series.LineSeries() { }; //tCosts = Total costs
                var breakevenPoint = new OxyPlot.Series.LineSeries() { MarkerType = MarkerType.Circle, MarkerSize = 4, Color = OxyColors.Red, Title = "Break-even point: " + intersectingPointX + " units" };

                tRevenue.Points.Add(new DataPoint(0, 0));
                tRevenue.Points.Add(new DataPoint(numofUnits, totalRevenue));

                tCosts.Points.Add(new DataPoint(0, fixedCosts));
                tCosts.Points.Add(new DataPoint(numofUnits, totalCosts));

                breakevenPoint.Points.Add(new DataPoint(intersectingPointX, getIntersectingPointY(numofUnits, totalRevenue, fixedCosts, numofUnits, totalCosts)));

                Graph.Model.Series.Clear();
                Graph.Model.Axes.Clear();

                Graph.Model.Series.Add(tRevenue);
                Graph.Model.Series.Add(tCosts);
                Graph.Model.Series.Add(breakevenPoint);

                Graph.Model.Axes.Add(new OxyPlot.Axes.LinearAxis()
                {
                    Position = AxisPosition.Left,
                    Minimum = 0,
                    Maximum = totalRevenue,
                    Key = "Y-Axis",
                    Title = "Revenue",
                    IsZoomEnabled = false,
                    IsPanEnabled = false
                });
                Graph.Model.Axes.Add(new OxyPlot.Axes.LinearAxis()
                {
                    Position = AxisPosition.Bottom,
                    Minimum = 0,
                    Maximum = numofUnits,
                    Key = "X-Axis",
                    Title = "Quantity sold",
                    IsZoomEnabled = false,
                    IsPanEnabled = false
                });

                Graph.InvalidatePlot(true);
            }
            else { MessageBox.Show("Invalid inputs"); }            
        }

        private void pricePerUnitBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateBreakeven(sender, e);
        }

        private void variableCostPerUnitBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateBreakeven(sender, e);
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Width = 950;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Width = 370;            
        }

        public float getIntersectingPointX(float x2, float y2, float y3, float x4, float y4)
        {
            float resultingX = ((x2 * 0 - 0 * y2) * (x4 - 0) - (x4 * y3 - 0 * y4) * (x2 - 0)) / ((x2 - 0) * (y4 - y3) - (x4 - 0) * (y2 - 0));
            return resultingX;
        }

        public float getIntersectingPointY(float x2, float y2, float y3, float x4, float y4)
        {
            float resultingY = ((x2 * 0 - 0 * y2) * (y4 - y3) - (x4 * y3 - 0 * y4) * (y2 - 0)) / ((x2 - 0) * (y4 - y3) - (x4 - 0) * (y2 - 0));
            return resultingY;
        }

        // Public = anything can call this
        /*public void update(List<listItem> itemList, DataGrid grid) {
            foreach (var item in grid.Items) {
                if (!itemList.Contains(item)) {
                    grid.Items.Remove(item);
                }
            }
        }*/
    }
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.model = new PlotModel() { Title = "Break-even chart" };            
        }
        public PlotModel model { get; private set; }                
    }
}
