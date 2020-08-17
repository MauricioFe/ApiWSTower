using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public interface IRelatoRepository
    {
        
        IEnumerable<Relatos> GetAll();
        Relatos Find(int id);
        void Add(Relatos relato);
        void Update(Relatos relato);
        void Remove(int id);
    }
}
