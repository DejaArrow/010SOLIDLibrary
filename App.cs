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
    class App
    {
        private string filetype = "JSON";
        private string filepath = "library.json";
        private LibraryHelper libraryHelper = new LibraryHelper();
        private List<Book> books;

        public App()
        {

        }

        public void Run()
        {
            CurrentTime time = new CurrentTime();
            while (true)
            {
                Console.Clear();
                time.Update();
                time.Display();

                switch (filetype)
                {
                    case "JSON":
                        LoadBookData loadBookData = new LoadBookData();
                        books = loadBookData.LoadJSON(filepath);
                        break;
                    case "XML":
                        LoadBookData loadBookData1 = new LoadBookData();
                        books = loadBookData1.LoadXML(filepath);
                        break;
                }
                bool done = false;

                string another = Input("Add a book y/n");
                if (another == "n")
                {
                    done = true;
                }

                while (!done)
                {
                    Console.Clear();
                    Console.WriteLine("Select a category:");
                    for (int i = 0; i < libraryHelper.Categories.Count; i++)
                    {
                        Console.WriteLine(i + ": " + libraryHelper.Categories[i]);
                    }

                    int selectedCategoryID = 0;
                    bool validID = false;
                    do
                    {
                        try
                        {
                            selectedCategoryID = Convert.ToInt32(Console.ReadLine());
                            if (selectedCategoryID >= 0 && selectedCategoryID < libraryHelper.Categories.Count)
                            {
                                validID = true;
                            }
                            else
                            {
                                Console.WriteLine("Option not available. Please try again");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Please try again");
                        }
                    } while (!validID);

                    string selectedCategory = libraryHelper.Categories[selectedCategoryID];
                    Console.WriteLine("You have sected {0}", selectedCategory);

                    string title = Input("Title");
                    string author = Input("Author");
                    string publisher = Input("Publisher");
                    string dateOfPublication = Input("Date of publication");

                    books.Add(new Book(title, author, publisher, dateOfPublication, selectedCategory));

                    another = Input("Add another? y/n");
                    if (another == "n")
                    {
                        done = true;
                    }

                };

                Console.Clear();
                Console.WriteLine("All books in library\n");
                foreach (var book in books)
                {
                    book.Display();
                }


                if (filetype == "JSON")
                {
                   SaveBookData saveBookData = new SaveBookData();
                   saveBookData.SaveJSON(books, filepath);
                }

                if (filetype == "XML")
                {
                    SaveBookData saveBookData = new SaveBookData();
                    saveBookData.SaveXML(books, filepath);

                }

                //Console.WriteLine(itemsSerialized);
                Console.ReadKey(true);
            }
        }
        public static string Input(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }
    }
}

