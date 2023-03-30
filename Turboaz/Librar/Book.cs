using System;
using System.Security.Principal;
using Turboaz.StableFeatures;

namespace Turboaz

{
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
        public string AuthorID { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }

        string? IIdentity.AuthenticationType => throw new NotImplementedException();

        bool IIdentity.IsAuthenticated => throw new NotImplementedException();

        string? IIdentity.Name => throw new NotImplementedException();

        public override string ToString()
        {
           return @$"Name.{Name}\n
                     Genre.{Genre}\n
                     PageCount.{PageCount}\n
                     Price.{Price}";
        }
    }
}