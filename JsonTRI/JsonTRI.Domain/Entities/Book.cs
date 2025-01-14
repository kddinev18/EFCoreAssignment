using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Domain.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesAvailable { get; set; }
    }
}