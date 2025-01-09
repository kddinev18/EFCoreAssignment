using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON1.Application.Mapping.PutDtos
{
    public class OrderPutDto
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
