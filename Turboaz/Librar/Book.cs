using System;
using Library.Storage;
using Library.StableFeatures;

namespace Library

{
    [Serializable]
    public class Book : IIdentity
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.Id = counter;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }

    
        public override string ToString()
        {
           return $"Name: {Name}\nGenre: {Genre}\nPageCount: {PageCount}\nPrice: {Price}";
        }
    }
}