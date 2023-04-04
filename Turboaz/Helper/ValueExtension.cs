using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Library.Helper
{
	public static partial class Extension
	{
		 static public int ReadInteger(string caption,bool checkInterval=false,int minValue=0,int maxValue=0)
		{
			int value;
		l1:
			Console.WriteLine(caption);
			if (!int.TryParse(Console.ReadLine(), out value))
			{
				goto l1;
			}
			return value;
			if(checkInterval &&(value<minValue||value>maxValue))
			{
				Console.WriteLine($"{value} Bu Intervalda Deyil [{minValue},{maxValue}]");
				goto l1;
			}
			return value;
		}
        static public string  ReadString(string caption)
        {
		l1:
			Console.Write(caption);
			string value = Console.ReadLine();
            
           if (string.IsNullOrWhiteSpace(value) || value.Any(Char.IsDigit))
            {
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("Mətn Daxil Edin");
             Console.ResetColor();
               goto l1;
           }
			return value.ChangeString();
        }
        static public decimal ReadDecimal(string caption)
		{
			decimal value;
		l1:
			Console.Write(caption);
			if (!decimal.TryParse(Console.ReadLine(), out value) || value <= 0)
			{
				Console.WriteLine("UYGUN EDEDI DAXIL EDIN:");
				goto l1;
			}
			return value;
		}
        public static string ChangeString(this string word)
        {
            StringBuilder build = new StringBuilder();
            string newWord = word.ToLower();
            build.Append(char.ToUpper(newWord[0]));
            build.Append(newWord.Substring(1));
            return build.ToString();
        }

    }

}