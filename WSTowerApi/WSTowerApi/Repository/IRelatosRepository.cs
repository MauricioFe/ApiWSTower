using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    interface IRelatosRepository
    {
        IEnumerable<Funcao> GetAll();
        Funcao Find(int id);
        void Add(Funcao funcao);
        void Update(Funcao funcao);
        void Remove(int id);
    }
}
