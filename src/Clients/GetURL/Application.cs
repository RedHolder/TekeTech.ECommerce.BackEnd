using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace GetURL
{
    internal class Application
    {
        public Application() { }

        public void GetList(string URL)
        {
            string filePath = @".\Data\Category.txt";

            try
            {
                // Read all lines from the file into a string array
                string[] lines = System.IO.File.ReadAllLines(filePath);

                // Convert the array to a list of strings
                List<string> Categories = new List<string>(lines);

                // Print the contents of the list
                foreach (string line in Categories)
                {
                    SendRequest(URL, line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetList(): {ex.Message}");
            }
        }


        public void SendRequest(string URL, string subURL) 
        {
            string message = DateTime.Now.ToString() + " : |INFO| " + subURL + " analysis started!";

            string filePath = @".\Data\log.txt";
            try
            {
                // Create a StreamWriter to append text to the file
                using (StreamWriter writer = System.IO.File.AppendText(filePath))
                {
                    writer.WriteLine(message);
                }

                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR :  {message + " || " + ex.Message}");
            }

            var client = new RestClient(URL);
            string RequestURLDetail = URL + subURL;

            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            bool status = response.IsSuccessStatusCode;

            
            

             filePath = @".\Data\DoneCategories.txt";

            try
            {
                // Create a StreamWriter to append text to the file
                using (StreamWriter writer = System.IO.File.AppendText(filePath))
                {
                    writer.WriteLine(subURL);
                }

                Console.WriteLine(subURL);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR :  {ex.Message}");
            }
            filePath = @".\Data\log.txt";
            message = DateTime.Now.ToString() + " : |INFO| " + subURL + " successfully analysed!";
            try
            {
                // Create a StreamWriter to append text to the file
                using (StreamWriter writer = System.IO.File.AppendText(filePath))
                {
                    writer.WriteLine(message);
                }

                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR :  {message + " || " + ex.Message}");
            }





        }
    }
}
