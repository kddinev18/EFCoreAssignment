using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Application.Mapping.PutDto
{
    public class PutBookDto
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
