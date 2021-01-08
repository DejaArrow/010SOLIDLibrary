using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system 
{
    public class Media : IDisplay
    {

        public static List<string> categories = new List<string> ();
       
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }

        public string Category{get; set;}
               

        public Media (string title, string publisher, string dateOfPublication, string category) 
        {
            Title = title;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Category = category;
                       
        }

        public virtual void Display () // Open Closed Principle
         {
             Console.WriteLine($"{Title}\n{Publisher}\n{DateOfPublication}\n{Category} ");
        }

      

    }
}