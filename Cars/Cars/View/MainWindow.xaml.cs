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
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace Cars
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IList<Car> car = new List<Car>();
            IList<Car> car2 = new List<Car>();
            car = Cars.ViewModel.CarViewModel.GetAll();
            car2 = Cars.ViewModel.CarViewModel.GetWeekendSale();
            

            //DataSet ds;
           // ds = Cars.ViewModel.CarViewModel.OpenXml();
            if (car != null)
            {
                //dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                dataGrid1.ItemsSource = car;
                dataGrid2.ItemsSource = car2;
            }
            
            

        }

        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
