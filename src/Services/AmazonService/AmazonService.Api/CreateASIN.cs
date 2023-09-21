using System.Text;

namespace AmazonService.Api
{
    public class CreateASIN
    {
        public Random random = new Random();

        public string GenerateRandomString(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }

        public string CreateASINCode()
        {
            int stringLength = 10; 
            string randomString = "B" + GenerateRandomString(stringLength - 1);

           return randomString.ToString();
        }

        public string CreateSKINCode()
        {
            int stringLength = 10;
            string randomString = "S" + GenerateRandomString(stringLength - 1);

            return randomString.ToString();
        }

    }
}
