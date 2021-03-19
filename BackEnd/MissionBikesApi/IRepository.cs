using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;


public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    Task<T> Get(int id);
    IEnumerable<T> Search(string search);
    // Task<T> Update(T t);
    // Task<T> Insert(T t);

}