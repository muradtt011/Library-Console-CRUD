using System;
namespace Turboaz.Helper
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
				Console.WriteLine($"{value} bu intervalda deyil [{minValue},{maxValue}]");
				goto l1;
			}
			return value;
		}
        static public string  ReadString(string caption)
        {
			Console.Write(caption);
			return Console.ReadLine();
        }
    }

}