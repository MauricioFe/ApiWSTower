using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    interface IRelatosRepository
    {
        IEnumerable<Relatos> GetAll();
        Relatos Find(int id);
        void Add(Relatos relatos);
        void Update(Relatos relatos);
        void Remove(int id);
    }
}
