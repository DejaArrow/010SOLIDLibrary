using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class Book : Media
    {
        [XmlIgnore]
        
        
        public string Author { get; set; }
        

        public Book(string title, string author, string publisher, string dateOfPublication, string category) : base (title, publisher, dateOfPublication, category)
        {
            
            Author = author;
           
            categories.Add(category); //Add to categories list so we can easily count how many we have
            int count = categories.Where(x => x.Equals(category)).Count(); //Using LINQ Count the number of existing books of this category
            ID = category.Substring(0, 4) + count.ToString("00");
        }

        public override void Display()
        {
            Console.WriteLine(ID + ", " + Author + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }

      


    }
}
