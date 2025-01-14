using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonTRI.Domain.Entities;

namespace JsonTRI.Infrastucture.Persistance
{
    internal class Json3Data
    {
        public List<Author> Author { get; set; }
        public List<Book> Books { get; set; }
        public List<BorrowRecord> BorrowRecords { get; set; }
        public List<Library> Libraries { get; set; }
    }
}