﻿using Marta_M.Entieties;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Entities
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DataBaseContext>();
            context.Database.EnsureCreated();
            if (!context.Books.Any())
            {

                try
                {
                    var books = new List<Book>()
                    {
                        new Book(){Title="Pan Tadeusz", DatePublication=new DateTime(1992), BasePrice= 12, CurrentPrice= 10 },
                        new Book(){Title="Przedwiośnie", DatePublication=new DateTime(1976), BasePrice= 22, CurrentPrice= 20 },
                        new Book(){Title="W pustyni i w puszczy", DatePublication=new DateTime(1942), BasePrice= 33, CurrentPrice= 30 },
                        new Book(){Title="Asiunia", DatePublication=new DateTime(1982), BasePrice= 44, CurrentPrice= 40 },

                    };

                    var authors = new List<Author>()
                    {
                        new Author(){FirstName="Adam",LastName="Mickiewicz" },
                        new Author(){FirstName="Juliusz",LastName="Słowacki" },
                        new Author(){FirstName="Dawid",LastName="Kucharczyk" },
                        new Author(){FirstName="Marta",LastName="Mazurkiewicz" },
                    };

                    context.Books.AddRange(books);
                    context.SaveChanges();

                    var authorbook = new List<AuthorBook>
                    {
                        new AuthorBook{ AuthorId=authors[0].Id,BookId=books[0].Id},
                        new AuthorBook{ AuthorId=authors[0].Id,BookId=books[1].Id},
                        new AuthorBook{ AuthorId=authors[1].Id,BookId=books[2].Id},
                        new AuthorBook{ AuthorId=authors[2].Id,BookId=books[3].Id}
                    };

                    context.AuthorBooks.AddRange(authorbook);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}
