﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;

namespace Marta_M.Entieties
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DatePublication { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<GenreBook> GenreBooks { get; set; }

    }
}
