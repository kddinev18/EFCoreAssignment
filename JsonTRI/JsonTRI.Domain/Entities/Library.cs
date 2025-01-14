using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Domain.Entities
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int EstablishedYear { get; set; }
    }
}