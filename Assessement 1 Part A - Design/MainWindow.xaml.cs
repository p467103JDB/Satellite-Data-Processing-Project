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
            // Load DLL from root dir
        }
        // Global Methods
        // 4.1 Two Data Structures
        LinkedList<double> SensorA = new LinkedList<double>();
        LinkedList<double> SensorB = new LinkedList<double>();

        // 4.2 Load DLL method

        // 4.3 Show all sensor data

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