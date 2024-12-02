using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        public ICollection<T> GetAll(int page, int pageSize);
        public T GetById(int id);
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
