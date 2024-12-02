using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment.Contracts
{
    public abstract class BaseJsonConverter<T> where T : class
    {
        public virtual string ConvertToJson(T obj)
        {
            // implement this method to convert the object to json
        }
        public virtual T ConvertFromJson(string json)
        {
            // implement this method to convert the json to object
        }
    }
}
