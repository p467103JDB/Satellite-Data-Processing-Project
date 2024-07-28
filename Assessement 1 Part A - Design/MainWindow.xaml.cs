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
            LoadData();
            // Load DLL from root dir
        }
        // Global Methods
        // 4.1 Two Data Structures - the only global variables that are allowed for this assignment
        LinkedList<double> Sensor_A = new LinkedList<double>();
        LinkedList<double> Sensor_B = new LinkedList<double>();
       

        // 4.2 Load DLL method
        private void LoadData()
        {
            const int total = 4; // 400 is the max required.
            ReadData readData = new ReadData(); // 4.2 - new instance of library required.

            for (int i = 0; i < total; i++)
            {
                Sensor_A.AddLast(readData.SensorA(double.Parse(MuVal.Text), double.Parse(SigmaVal.Text)));
                Sensor_B.AddLast(readData.SensorB(double.Parse(MuVal.Text), double.Parse(SigmaVal.Text)));
            }
            ShowAllSensorData();
        }

        // 4.3 Show all sensor data
        private void ShowAllSensorData()
        {
            /*
            Create a custom method called “ShowAllSensorData” which will display both LinkedLists in a ListView. 
            Add column titles “Sensor A” and “Sensor B” to the ListView. The input parameters are empty, and the return type is void. 
            */
            ListViewSensorA.Items.Clear();
            ListViewSensorB.Items.Clear();

            foreach (double data in Sensor_A)
            {

                ListViewSensorA.Items.Add(data);

            }
            foreach (double data in Sensor_B)
            {
                ListViewSensorB.Items.Add(data.ToString());
            }

            //ListViewSensorA.ItemsSource = Sensor_A;
            //ListViewSensorB.ItemsSource = Sensor_B;
        }

        // 4.4 Button Method - Triggers Load Data & Show all sensor data


        // Utility Methods
        #region Utility Methods
        // 4.5 Number of nodes Method 

        // 4.6 Display List box data - Displays content of LinkedList ubsude appropriate listbox. - Method signature requires two input parameters.

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