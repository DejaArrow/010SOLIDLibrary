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
    public class LoadBookData
    {
        public LoadBookData()
        {
            
        }

        public List<Book> LoadJSON(string filepath)
        {
            if (File.Exists(@filepath))
                        {
                            string exisitingData;
                            using (StreamReader reader = new StreamReader(@filepath, Encoding.Default))
                            {
                                exisitingData = reader.ReadToEnd();
                            }
                            return JsonConvert.DeserializeObject<List<Book>>(exisitingData);
                        }
            else
            {
                 return new List<Book>();
            }

        }

        public List<Book> LoadXML(string filepath)
        {
            if (File.Exists(@filepath))
                        {
                            var serializer = new XmlSerializer(typeof(List<Book>));
                            using (var reader = new StreamReader(@filepath))
                            {
                                try
                                {
                                    return (List<Book>)serializer.Deserialize(reader);
                                }
                                catch
                                {
                                    Console.WriteLine("Could not load file");
                                     return new List<Book>();
                                } 
                            }
                        }
            else
            {
                return new List<Book>();
            }
        }
    }
}