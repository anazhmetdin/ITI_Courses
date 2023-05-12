using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.DataService
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T student);
        void Update(T student);
        void Delete(int id);


    }
}
