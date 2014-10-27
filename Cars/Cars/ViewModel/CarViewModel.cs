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

            // xml file
            



            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {

                // Open document 
                filename = dlg.FileName;
                

                

                

            }
            


            
        }

        /*
        public static  DataSet OpenXml()
        {
            // xml file
            //string filename = null;
            DataSet dataset = new DataSet();
            
            

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                
                // Open document 
                filename = dlg.FileName;
                dataset.ReadXml(filename);
                
                return dataset;
                
                //xmldata.DataSet.ReadXml(filename);

            }

            else
            {
                return null;
            }


        }
        */
        
        public static IList<Car> GetAll()
        {
            //IList<Car> result = new List<Car>();
            GetFilename();
            

               
                
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

                //cars = result;
                return result;

            

            

        }

        public static IList<Car> GetWeekendSale()
        {
            result.Where(a => a.Name.Equals("Skoda Octavia")).Where(a => (a.Date_of_sale.DayOfWeek == DayOfWeek.Saturday || a.Date_of_sale.DayOfWeek == DayOfWeek.Sunday)).Sum(a => a.Price);

           
            return result;
            
        }
         

        /*
        public static XmlDataDocument ShowXml(string filename)
        {
            
            XDocument xmlDoc = XDocument.Load(filename);
            XmlDataDocument xmldata = new XmlDataDocument();
            xmldata.DataSet.ReadXml(filename);
            

            return xmldata;
            

        }
         */ 
         

       

        
    }
}
