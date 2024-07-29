using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using Galileo6; // i thought it was wrong before... but it was right - import new library
// ReadData Decompiled say it's a class - so i need to create an object of the class to use its methods sooo
// ReadData reader = new ReadData(); is required ahead.


namespace Assessement_1_Part_A___Design
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
        // 4.1 Two Data Structures - the only global variables that are allowed for this assignment
        LinkedList<double> Sensor_A = new LinkedList<double>();
        LinkedList<double> Sensor_B = new LinkedList<double>();
       
        // Global Methods
        #region Global Methods
        // 4.2 Load DLL method
        private void LoadData()
        {
            const int total = 400; // 400 is the max required.
            Sensor_A.Clear();
            Sensor_B.Clear();

            ReadData readData = new ReadData(); // 4.2 - new instance of library required.
            for (int i = 0; i < total; i++)
            {
                Sensor_A.AddLast(readData.SensorA(double.Parse(MuVal.Text), double.Parse(SigmaVal.Text))); // Get text from Sigma and MU and parse them.
                Sensor_B.AddLast(readData.SensorB(double.Parse(MuVal.Text), double.Parse(SigmaVal.Text))); // I think theres probably a better way of doing this but it works for now.
            }
        }

        // 4.3 Show all sensor data
        private void ShowAllSensorData()
        {
            ListViewSensorA.Items.Clear(); // Clear listviews
            ListViewSensorB.Items.Clear();
            foreach (double data in Sensor_A) // add to listviews to display them
            {
                ListViewSensorA.Items.Add(data);
            }
            foreach (double data in Sensor_B)
            {
                ListViewSensorB.Items.Add(data);
            }
        }

        // 4.4 Button Method - Triggers LoadData & Showallsensordata
        private void Load_Data_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            ShowAllSensorData();
            DisplayListboxData();
        }
        #endregion

        // Utility Methods
        #region Utility Methods
        // 4.5 Number of nodes Method 
        private void Get_Total_Nodes()
        {

            // Im assuming i need to collect the listview/linkedlist from a button that passes the specified list through.
            // But if im generating 400 doubles per linkedlist to begin with... why is this ever needed if i know that the number is always 400?

        }

        // 4.6 Display List box data - Displays content of LinkedList inside appropriate listbox. - Method signature requires two input parameters
        // 
        /*
        Create a method called “DisplayListboxData” that will display the content of a LinkedList inside the appropriate ListBox. 
        method signature will have two input parameters; a LinkedList, and the ListBox name.  
        calling code argument is the linkedlist name and the listbox name. 
         */

        private void DisplayListboxData()
        {
            // Can this be done in a better way??? I think creating a new item for everyloop seems a bit extreme, i mean it literally doubles the memory usage i assume. <------ *FIND BETTER SOLUTION*
            ListBoxSensorData.Items.Clear();
            //List<(double Column1, double Column2)> combinedList = Sensor_A.Zip(Sensor_B, (item1, item2) => (Column1: item1, Column2: item2)).ToList(); // sorcery

            var nodeA = Sensor_A.First;
            var nodeB = Sensor_B.First;
            for (int i = 0; i < Sensor_A.Count; i++)
            {
                var clData = new { Column1 = nodeA.Value, Column2 = nodeB.Value }; // Yeah figuring this out was a complete fluke, i was fortunate the autofill knew what I was doing here.
                ListBoxSensorData.Items.Add(clData);
                nodeA = nodeA.Next;
                nodeB = nodeB.Next; 
            }


            // This one is dumb, i know it is but it works for now.... Will ask Milan on how it could be improved
            /*
            foreach(var item in combinedList) 
            { 
                var clData = new { Column1 = item.Column1, Column2 = item.Column2 }; // Yeah figuring this out was a complete fluke, i was fortunate the autofill knew what I was doing here.
                ListBoxSensorData.Items.Add(clData);
            }*/


            // You'd this this one would work but no.....
            /*
            foreach (var (column1, column2) in combinedList)
            {
                ListBoxSensorData.Items.Add((column1, column2));
            }*/
        }

        #endregion

        // Sort and search methods.
        #region Sort and Search
        // 4.7 Selection Sort - Refer to psuedo code in appendix of AP 1 Part B

        // 4.8 Insertion Sort - Same as above

        // 4.9 Binary Search Iterative - 

        // 4.10 Binary Search Recursive
        #endregion

        // UI Buttons
        #region UI Buttons
        // 4.11 Button click methods SEARCH - search linked list for an int value entered via textbox
        // a. method sensor A binary search iterative
        // b. method sensor A binary search recursive
        // c. method sensor B binary search iterative
        // d. method sensor B binary search recursive


        // 4.12 button click methods SORT - sort  linked list using selection andinsertion methods.
        // a. method sensor A selection sort
        // b. method sensor A insertion sort
        // c. method sensor B selection sort
        // d. method sensor B insertion sort
        #endregion

        // 4.13 Numeric input control for SIGMA (Min value 10 - max 20) and Mu (Min value 35 - max 75 - DEFAULT 50)

        // 4.14 textboxes for search value

        // 4.15 code must be adequately commented - Map the programming criteria and features to your code/methods by
        // adding comments/regions above the method signatures.
        // Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/). 




    }
}