using Turboaz;
using Turboaz.Helper;
using Turboaz.StableFeatures;
using Turboaz.Storage;

namespace Turboaz;
class Program
{
    static void Main(string[] args)
    {
        var authorStore = new GenericStore< Author>();
        var bookStore = new GenericStore<Book>();

        int Id;
        Menu menu;
        l1: menu= Extension.PrintMenu();
      switch(menu)
        {
            case StableFeatures.Menu.AuthorGetAll:
                Console.Clear();
                if(authorStore.Length==0)
                {
                    Console.WriteLine("Author bosdur,yeni Author Elave edin:");
                    goto case Menu.AuthorAdd;
                }
                Console.WriteLine($"=========== AUTHOR ===========");
                foreach(var item in authorStore)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Surname}");
                }
                Console.WriteLine($"========== ======== ==========");
                goto l1;

            case StableFeatures.Menu.AuthorGetById:
                break;
            case StableFeatures.Menu.AuthorAdd:
                Console.Clear();
                Console.Write("Author Adini Daxil Edin:");
                string name = Console.ReadLine();
                Author m = new Author();
                m.Name = name;
                authorStore.Add(m);
                Console.WriteLine("Elave Edildi:");
                goto l1;
            case StableFeatures.Menu.AuthorFindName:
                break;
            case StableFeatures.Menu.AuthorEdit:
                Console.Clear();
                Console.WriteLine($"=========== AUTHOR ===========");
                foreach (var item in authorStore)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Surname}");
                }
                Console.WriteLine($"========== ======== ==========");
                Id = Extension.ReadInteger("Marka id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                var authorFound=authorStore.Find(Id);
                if(authorFound==null)
                {
                    goto case Menu.AuthorEdit;
                }
                authorFound.Name = Extension.ReadString("Author adini yaz:");
                authorFound.Surname = Extension.ReadString("Author soyadini yaz:");
                goto case Menu.AuthorGetAll;
                
            case StableFeatures.Menu.AuthorRemove:
                Console.Clear();
                Console.WriteLine($"=========== AUTHOR ===========");
                foreach (var item in authorStore)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Surname}");
                }
                Console.WriteLine($"========== ======== ==========");
                Id = Extension.ReadInteger("Marka id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                var authorFound2 = authorStore.Find(Id);
                if (authorFound2 == null)
                {
                    goto case Menu.AuthorRemove;
                }
                authorStore.Remove(authorFound2);
                goto case Menu.AuthorGetAll;

                break;
            case StableFeatures.Menu.BookGetAll:
                break;
            case StableFeatures.Menu.BookGetById:
                break;
            case StableFeatures.Menu.BookAdd:
                break;
            case StableFeatures.Menu.BookFindName:
                break;
            case StableFeatures.Menu.BookEdit:
                break;
            case StableFeatures.Menu.BookRemove:
                break;
            case StableFeatures.Menu.ExitFromApp:
                break;
                Console.WriteLine("Cixis Ucun Her Hansi Duymeni Basin!");
                Console.ReadKey();
            default:
                break;
        }

        return;
        
       
   
         
            foreach (var item in authorStore)
            {
                Console.WriteLine(item);
                return;

            }
        }
    }

   

