using DataLayerLib1;
using System.Diagnostics;
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

namespace WPF_NorthwindUebungTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NorthwindContext DB {  get; set; } 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB = new NorthwindContext();
            try
            {
                var costumerlist = DB.Customers
                    .Where(x => x.Orders.Any(y=>y.ShipCountry == x.Country && y.Freight != null))
                    .OrderBy(x=>x.ContactName)
                    .ToList();
                        
              var customerlist2 = costumerlist.Select(x => x.ContactName[0]).Distinct().ToList();
                Debug.WriteLine(costumerlist.ToString());
                coB.ItemsSource = customerlist2;
            }catch  (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void coB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbK.ItemsSource = DB.Customers.ToList();
        }

        private void btnRabatt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}