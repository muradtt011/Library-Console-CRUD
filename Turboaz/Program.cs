using System.Runtime.Serialization.Formatters.Binary;
using Library;
using Library.Helper;
using Library.StableFeatures;
using Library.Storage;

namespace Library;
class Program
{
    const string databaseFile = "database.dat";
    static GenericStore<Author> authorStore = new GenericStore<Author>();
    static GenericStore<Book> bookStore = new GenericStore<Book>();
    static void Main(string[] args)
    {
        using (FileStream FileStream = File.Open(databaseFile, FileMode.OpenOrCreate))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                var db = (Database)bf.Deserialize(FileStream);
                if (db != null)
                {
                    authorStore = db.authors;
                    bookStore = db.books;
                }
            }
            catch (Exception ex)
            {

            }
        }
        int Id;
        bool allowForClear = true;
        Author author;
        Book book;
        Menu menu;
    l1: menu = Extension.PrintMenu();
        switch (menu)
        #region AuthorGetAll
        {
            case StableFeatures.Menu.AuthorGetAll:
                Console.Clear();
                if (authorStore.Length == 0)
                {
                    Console.WriteLine("Author bosdur,yeni Author Elave edin:");
                    goto case Menu.AuthorAdd;
                }
                ShowAllAuthor(false);
                goto l1;
            #endregion

        #region AuthorGetById
            case StableFeatures.Menu.AuthorGetById:
                ShowAllAuthor(true);
            l2:
                Id = Extension.ReadInteger("Author id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                author = authorStore.Find(Id);
                if (author == null)
                {
                    Console.WriteLine($"AUTHOR MOVCUD DEYIL:");
                    goto l1;
                }
                Console.WriteLine(author);
                goto l1;
            #endregion

        #region AuthorAdd
            case StableFeatures.Menu.AuthorAdd:
                if (allowForClear)
                    Console.Clear();
                author = new Author();
                author.Name = Extension.ReadString("Author Adini Daxil Edin: ");
                author.Surname = Extension.ReadString("Author soyadini daxil edin: ");
                authorStore.Add(author);
                Console.WriteLine("Elave Edildi:");
                goto l1;
            #endregion

        #region AuthorFindByName
            case StableFeatures.Menu.AuthorFindByName:
                Console.Clear();
                Console.WriteLine($"=========== AUTHOR ===========");
                foreach (var item in authorStore)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Surname}");
                }
                Console.WriteLine($"========== ======== ==========");
            l5:
                string name = Extension.ReadString("Muellif adi ile axtaris: ");
                var data = authorStore.FindName(name);
                if (data.Length == 0)
                {
                    Console.WriteLine($"BU Muellif movcud deyil:");
                    goto l5;
                }
                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }
                goto l1;
            #endregion

        #region AuthorEdit
            case StableFeatures.Menu.AuthorEdit:
                ShowAllAuthor(true);
                Id = Extension.ReadInteger("Author id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                author = authorStore.Find(Id);
                if (author == null)
                {
                    goto case Menu.AuthorEdit;
                }
                author.Name = Extension.ReadString("Author adini yaz:");
                author.Surname = Extension.ReadString("Author soyadini yaz:");
                goto case Menu.AuthorGetAll;
            #endregion

        #region AuthorRemove
            case StableFeatures.Menu.AuthorRemove:
                ShowAllAuthor(true);
                Id = Extension.ReadInteger("Author id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                author = authorStore.Find(Id);
                if (author == null)
                {
                    goto case Menu.AuthorRemove;
                }
                authorStore.Remove(author);
                goto case Menu.AuthorGetAll;
            #endregion

        #region BookGetAll
            case StableFeatures.Menu.BookGetAll:
                if (bookStore.Length == 0)
                {

                    Console.WriteLine("Booklar bosdur,yeni Book Elave edin:");
                    goto case Menu.BookAdd;
                }
                ShowAllBook(true);
                goto  l1;
            #endregion

        #region BookGetById
            case StableFeatures.Menu.BookGetById:
                ShowAllBook(true);
                Console.WriteLine($"========== ======== ==========");
            l6:
                Id = Extension.ReadInteger("Book id:", true, bookStore.Min(x => x.Id), bookStore.Max(x => x.Id));
                author = authorStore.Find(Id);
                if (author == null)
                {
                    Console.WriteLine($"Book  MOVCUD DEYIL:");
                    goto l6;
                }
                Console.WriteLine(author);
                goto l1;
            #endregion

        #region BookAdd
            case StableFeatures.Menu.BookAdd:
                Console.Clear();

                if (authorStore.Length == 0)
                {
                    allowForClear = false;
                    Console.WriteLine("Authorlar bosdur,authorlar elave edilmelidir!");
                    goto case Menu.AuthorAdd;
                }

                book = new Book();
                book.Name = Extension.ReadString("KITAB Adini Daxil Edin: ");
                book.Genre = Extension.ReadGenre("KITAB Janrini Daxil edin:");
                book.PageCount = Extension.ReadInteger("KITAB vereq sayini daxil edin:");
                book.Price = Extension.ReadDecimal("KITAB qiymetini daxil edin:");
                ShowAllAuthor(false);
            l3:
                Id = Extension.ReadInteger("Author id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                if (!authorStore.Any(x => x.Id == Id))
                {
                    Console.WriteLine($"Author Movcud Deyil,siyahidan secin");
                    goto l3;
                }
                book.AuthorID = Id;
                bookStore.Add(book);
                Console.WriteLine("Elave Edildi:");
                goto l1;
            #endregion

        #region BookFindByName
            case StableFeatures.Menu.BookFindByName:
                Console.Clear();
                Console.WriteLine("=======Kitablar=======");
                foreach (var item in bookStore)
                {
                    Console.WriteLine($"{item.Id} {item.Name}");
                }
                Console.WriteLine("========================");
            l7:
                string name1 = Extension.ReadString("Kitab adı ilə axtarış: ");
                var data1 = bookStore.FindName(name1);
                if (data1.Length == 0)
                {
                    Console.WriteLine($"Bu kitab mövcud deyil");
                    goto l7;
                }
                foreach (var item in data1)
                {
                    Console.WriteLine(item);
                }
                goto l1;
            #endregion

        #region BookEdit
            case StableFeatures.Menu.BookEdit:
                ShowAllBook(true);
                Id = Extension.ReadInteger("Book id:", true, bookStore.Min(x => x.Id), bookStore.Max(x => x.Id));
                book = bookStore.Find(Id);
                if (book == null)
                {
                    goto case Menu.AuthorEdit;
                }
                book.Name = Extension.ReadString("Book adini yaz:");
                ShowAllAuthor(false);
            l4:
                Id = Extension.ReadInteger("Author id:", true, authorStore.Min(x => x.Id), authorStore.Max(x => x.Id));
                if (!authorStore.Any(x => x.Id == Id))
                {
                    Console.WriteLine($"Author Movcud Deyil,siyahidan secin");
                    goto l4;
                }
                book.AuthorID = Id;

                goto case Menu.BookGetAll;
            #endregion

        #region BookRemove
            case StableFeatures.Menu.BookRemove:
                ShowAllBook(true);
                Id = Extension.ReadInteger("Book id:", true, bookStore.Min(x => x.Id), bookStore.Max(x => x.Id));
                book = bookStore.Find(Id);
                if (book == null)
                {
                    goto case Menu.BookRemove;
                }
                bookStore.Remove(book);
                goto case Menu.BookGetAll;
            #endregion

        #region SaveAndExit
            case StableFeatures.Menu.SaveAndExit:
                
                Database db = new Database();
                db.authors = authorStore;
                db.books = bookStore;
                FileStream FileStream = File.Create(databaseFile);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(FileStream, db);
                FileStream.Flush();
                FileStream.Close();
                
                Console.WriteLine("Cixis Ucun Her Hansi Duymeni Basin!");
                Console.ReadKey();
                break;
            #endregion
            default:
                break;
        }
    }

    private static void ShowAllAuthor(bool clearBefore)
    {
        if (clearBefore)
        {
            Console.Clear();
        }
        Console.WriteLine($"=========== AUTHOR ===========");
        foreach (var item in authorStore)
        {
            Console.WriteLine($"{item.Id} {item.Name} {item.Surname}");
        }
        Console.WriteLine($"========== ======== ==========");
    }

    private static void ShowAllBook(bool clearBefore)
    {
        if (clearBefore)
        {
            Console.Clear();
        }
        Author author;
        Console.WriteLine($"=============BOOKS===============");
        foreach (var item in bookStore)
        {
            author = authorStore.Find(item.AuthorID);
            Console.WriteLine($"{item.Id}\nKitabin adi: {item.Name}\nMuellif: {author.Name} {author.Surname}\nSehife sayi: {item.PageCount}"+
                $"\nJanri: {item.Genre}\nQiymeti: {item.Price} azn ");
        }
    }

}
