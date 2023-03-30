using System;
using Turboaz.StableFeatures;

namespace Turboaz.Helper
{
	public partial class Extension
	{
        public static Menu PrintMenu()
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Type type = typeof(Menu);
       
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=========== MENU ===========");
            foreach (var item in Enum.GetValues(type))
            {
                Console.WriteLine($"{((int)item).ToString().PadLeft(2,'0')}. {item}");
            }
            Console.WriteLine($"============================");
            Console.ForegroundColor = tempColor;
        l1: Console.Write("REJIMI SECIN:");
            if (!Enum.TryParse<Menu>(Console.ReadLine(), out Menu selectedMenu)
                || !Enum.IsDefined(type, selectedMenu))
            {
                goto l1;
            }
            return selectedMenu;
        }
    }
}

