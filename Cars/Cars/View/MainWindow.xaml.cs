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


        class StringValue
        {
            public StringValue(string s)
            {
                _value = s;
            }
            public string Value { get { return _value; } set { _value = value; } }
            string _value;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IList<Car> car = new List<Car>();
            
            car = Cars.ViewModel.CarViewModel.GetAll();
            

            
            if (car != null)
            {
                
                dataGrid1.ItemsSource = car;

                IList<StringValue> resultText = new List<StringValue>();
                IList<string> carModels = car.Select(c => c.Name).Distinct().ToList();
                foreach (string name in carModels)
                {
                    double price = (car.Where(a => a.Name.Equals(name)).Where(a => (a.Date_of_sale.DayOfWeek == DayOfWeek.Saturday || a.Date_of_sale.DayOfWeek == DayOfWeek.Sunday)).Sum(a => a.Price));
                    double tax = (car.FirstOrDefault(c => c.Name.Equals(name)).DPH);
                    double priceDPH = price + (price * (tax / 100));
                    string text = name + "\r\nCena bez DPH: "  + price.ToString("f2") + "   Cena s DPH: " + priceDPH.ToString("f2");
                    resultText.Add(new StringValue(text));
                }


                

                
                dataGrid2.ItemsSource = resultText;

                
                var template = new DataTemplate();
                template.VisualTree = new FrameworkElementFactory(typeof(TextBlock));
                template.VisualTree.SetValue(TextBlock.TextProperty, "Weekend sale");
                dataGrid2.Columns[0].HeaderTemplate = template;

                
            }

            

        }

        

        
    }
}
