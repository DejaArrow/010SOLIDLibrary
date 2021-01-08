using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace library_system
{
    public class SaveBookData
    {
        public SaveBookData()
        {

            
        }

        public void SaveJSON(List<Book> books, string filepath)
        {   
             using (StreamWriter file = File.CreateText(@filepath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, books);
                    }
        }
        
        public void SaveXML(List<Book> books, string filepath)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
                    using (var writer = new StreamWriter(@"library.xml"))
                    {
                        serializer.Serialize(writer, books);
                    }
        }
    }
}