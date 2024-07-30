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
            const int total = 4; // 400 is the max required.
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
            ListViewSensorData.Items.Clear();
            var nodeA = Sensor_A.First; // im duplicating the linkedlist so that i dont fw the original. is this bad?
            var nodeB = Sensor_B.First;
            for (int i = 0; i < Sensor_A.Count; i++)
            {
                var clData = new { Column1 = nodeA.Value, Column2 = nodeB.Value }; // Yeah figuring this out was a complete fluke, i was fortunate the autofill knew what I was doing here.
                ListViewSensorData.Items.Add(clData);
                nodeA = nodeA.Next;
                nodeB = nodeB.Next;
            }
        }

        // 4.4 Button Method - Triggers LoadData & Showallsensordata
        private void Load_Data_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            ShowAllSensorData();
            DisplayListboxData(Sensor_A, ListBoxSensorA); // Mickey mouse pointless exercise... it's done however
            DisplayListboxData(Sensor_B, ListBoxSensorB);
        }
        #endregion

        // Utility Methods
        #region Utility Methods
        // 4.5 Number of nodes Method 
        private int NumberOfNodes(LinkedList<double> lListNode)
        {
            return lListNode.Count;
        }

        // 4.6 Display List box data - Displays content of LinkedList inside appropriate listbox. - Method signature requires two input parameters
        private void DisplayListboxData(LinkedList<double> lList , ListBox lBox )
        {
            lBox.Items.Clear();
            foreach (double data in lList) // add to listviews to display them
            {
                var cA = new { Column = data };
                lBox.Items.Add(cA);
            }
        }

        #endregion

        // Sort and search methods.
        #region Sort and Search
        // 4.7 Selection Sort - Refer to psuedo code in appendix of AP 1 Part B *DONE*
        private bool SelectionSort(LinkedList<double> lListSort)
        {
            int min;
            int max = NumberOfNodes(lListSort);
            for (int i = 0; i < max - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < max; j++)
                {
                    if (lListSort.ElementAt(j) < lListSort.ElementAt(min)) // is element 1 smaller than element 0
                    {
                        min = j;
                    }
                }
                LinkedListNode<double> currentMin = lListSort.Find(lListSort.ElementAt(min));
                LinkedListNode<double> currentI = lListSort.Find(lListSort.ElementAt(i));
                var temp = currentMin.Value;
                currentMin.Value = currentI.Value;
                currentI.Value = temp;
            }
            return true;
        }

        // 4.8 Insertion Sort - Same as above *DONE*
        private bool InsertionSort(LinkedList<double> lListSort)
        {
            int max = NumberOfNodes(lListSort) - 1;

            for (int i = 0; i < max; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (lListSort.ElementAt(j - 1) > lListSort.ElementAt(j))
                    {
                        LinkedListNode<double> current = lListSort.Find(lListSort.ElementAt(j));
                        var temp = lListSort.ElementAt(j - 1);
                        current.Previous.Value = lListSort.ElementAt(j); // that is what stumped me for 30 minutes. gadddfkndammit
                        current.Value = temp;
                    }
                }
            }
            return true;
        }

        // 4.9 Binary Search Iterative - 
        private int BinarySearchIterative (LinkedList<double> lListSearch, int searchValue, int minimum, int maximum)
        {
            while (minimum <= maximum - 1)
            {
                int mid = minimum + maximum / 2;
                if (searchValue == lListSearch.ElementAt(mid))
                {
                    return mid;
                }
                else if (searchValue < lListSearch.ElementAt(mid))
                {
                    maximum = mid -1;
                }
                else
                {
                    minimum = mid+1;
                }
            }
            return minimum;
        }

        // 4.10 Binary Search Recursive
        #endregion

        // UI Buttons
        #region UI Buttons
        // 4.11 Button click methods SEARCH - search linked list for an int value entered via textbox
        // a. method sensor A binary search iterative
        private void ButtonIterativeSearch_A_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchValue_A.Text) && Sensor_A.Count != 0)
            {
                int searchVal = int.Parse(SearchValue_A.Text.Trim());
                int indexFound = BinarySearchIterative(Sensor_A, searchVal, 0, Sensor_A.Count());



                
            }
            else if (Sensor_A.Count == 0)
            {
                StatusMessage.Text = "Iterative Search of Sensor A: Unsuccessful - Sensor A requires entries to sort.";
            }
            else
            {
                StatusMessage.Text = "Iterative Search of Sensor A: Unsuccessful - Search value cannot be empty.";
            }

        }
        // b. method sensor A binary search recursive
        // c. method sensor B binary search iterative
        // d. method sensor B binary search recursive


        // 4.12 button click methods SORT - sort  linked list using selection andinsertion methods.
        // a. method sensor A selection sort
        private void ButtonSelectionSort_A_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionSort(Sensor_A) && Sensor_A.Count != 0)
            {
                StatusMessage.Text = "Selection Sort of Sensor A: Successful";
                DisplayListboxData(Sensor_A, ListBoxSensorA);
            }
            else
            {
                StatusMessage.Text = "Selection Sort of Sensor A: Unsuccessful - Sensor A requires entries to sort.";
            }
        }
        // b. method sensor A insertion sort
        private void ButtonInsertionSort_A_Click(object sender, RoutedEventArgs e)
        {
           if (InsertionSort(Sensor_A) && Sensor_A.Count != 0)
            {
                StatusMessage.Text = "Insertion sort of Sensor A: Successful";
                DisplayListboxData(Sensor_A, ListBoxSensorA);
            }
            else
            {
                StatusMessage.Text = "Insertion Sort of Sensor A: Unsuccessful - Sensor A requires entries to sort.";
            }
        }
        // c. method sensor B selection sort



        // d. method sensor B insertion sort


        #endregion

        // 4.13 Numeric input control for SIGMA (Min value 10 - max 20) and Mu (Min value 35 - max 75 - DEFAULT 50) - done

        // 4.14 textboxes for search value

        // 4.15 code must be adequately commented - Map the programming criteria and features to your code/methods by
        // adding comments/regions above the method signatures.
        // Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/). 
    }
}