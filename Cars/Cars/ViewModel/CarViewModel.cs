using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;
using System.Xml;
using Cars.ViewModel;
using Cars;
using System.Globalization;

namespace Cars.ViewModel
{
    public class CarViewModel
    {

        static string filename;
        static XmlDocument doc = new XmlDocument();
        static IList<Car> result = new List<Car>();

        public static void GetFilename()
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {

                filename = dlg.FileName;
                

            }
            
            
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

        
        public static IList<Car> GetAll()
        {
            
            GetFilename();
            result.Clear();
            if (filename != null)
            {
               
                
                doc.Load(filename);
                foreach(XmlNode node in doc.ChildNodes[1].ChildNodes)
                {
                    Car car = new Car();
                    car.Name = (node.SelectNodes("Name").Item(0).FirstChild.Value);
                    car.Date_of_sale = DateTime.Parse(node.SelectNodes("Date_of_sale").Item(0).FirstChild.Value);
                    car.Price = Convert.ToDouble(node.SelectNodes("Price").Item(0).FirstChild.Value);
                    car.DPH = Convert.ToDouble(node.SelectNodes("DPH").Item(0).FirstChild.Value);
                    result.Add(car);

                    

                }

                
                filename = null;
                return result;
            }

            else
            {
                return null;
            }
            

            

        }

        
         

       
         

       

        
    }
}
