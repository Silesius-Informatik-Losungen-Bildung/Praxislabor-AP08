using StempelAppCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempelAppCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public T Add(int id) => 

        public T Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
