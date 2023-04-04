using System;
using Library.StableFeatures;

namespace Library.Helper
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
                Console.WriteLine($"{((int)item).ToString().PadLeft(2, '0')}. {item}");
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
        public static Genre ReadGenre(string caption)
        {
            Console.Clear();
            Console.Write(caption);
            Type type = typeof(Genre);
            Console.Clear();
            Console.WriteLine("JANR SECIN:");
            foreach(var item in Enum.GetValues(type))
            {
                Console.WriteLine($"{((byte)item).ToString().PadLeft(2, '0')}.{item}");
            }
            
        l1:
            if (!Enum.TryParse<Genre>(Console.ReadLine(), out Genre selectedGenre)
                || !Enum.IsDefined(type, selectedGenre))
            {
                Console.WriteLine("Duzgun daxil edilmeyib:");
                goto l1;
            }
            return selectedGenre;
        }
    }
}

