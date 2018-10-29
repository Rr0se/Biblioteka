using Marta_M.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Entities
{
    public class PublisherBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PublisherId { get; set; }
        public Book Book { get; set; }
        public Publisher Publisher { get; set; }
    }
}
