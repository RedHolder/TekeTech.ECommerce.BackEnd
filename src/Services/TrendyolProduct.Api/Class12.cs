namespace TrendyolProduct.Api
{
    public class Class12
    {

        public List<string> ReadFileLines(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                // Read all lines from the file
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return lines;
        }
    }
}
