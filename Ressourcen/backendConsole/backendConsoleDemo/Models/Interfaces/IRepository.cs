using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempelAppCore.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(int id);
        T Get(int id);
        T Update(int id);
        T Delete(int id);
    }
}