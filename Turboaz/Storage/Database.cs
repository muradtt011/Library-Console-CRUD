using System;
namespace Library.Storage
{

	[Serializable]
 public class Database
	{
		public GenericStore<Author> authors { get; set; }

	    public GenericStore<Book> books { get; set; }
		
	}
} 

