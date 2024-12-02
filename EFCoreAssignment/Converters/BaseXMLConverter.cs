using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment.Contracts
{
    internal abstract class BaseXMLConverter<T> where T : class
    {
        public virtual string ConvertToXML(T obj)
        {
            // implement this method to convert the object to json
        }
        public virtual T ConvertFromXML(string json)
        {
            // implement this method to convert the json to object
        }
    }
}
