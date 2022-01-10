using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        
        public static string SplitToLines(string str, int n)
        {
            var sb = new StringBuilder(str.Length + (str.Length + 9) / 10);

            for (int q = 0; q < str.Length;)
            {
                sb.Append(str[q]);

                if (++q % n == 0)
                    sb.AppendLine();
            }

            if (str.Length % n == 0)
                --sb.Length;

            return sb.ToString();
        }

        static void Main(string[] args)
        {

            string path = @"I:\SomeDir2\rrr";
            //string path = @"I:\SomeDir2\jjj.mp4";

            using (FileStream fstream = File.OpenRead($"{path}"))
            {
      
                byte[] array = new byte[fstream.Length];
                
                fstream.Read(array, 0, array.Length);

                //string textFromFile = System.Text.Encoding.Default.GetString(array);
                //string textFromFile = System.Text.Encoding.ASCII.GetString(array);

                string hexString = BitConverter.ToString(array);
                
                hexString = hexString.Replace("-", " ");
                
                Console.WriteLine(SplitToLines(hexString, 48));
                //Console.WriteLine(textFromFile);
            }

            Console.ReadLine();
        }
    }
}
