using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public interface IRelatosRepository
    {
        IEnumerable<Relato> GetAll();
        Relato Find(int id);
        void Add(Relato relato);
        void Update(Relato relato);
        void Remove(int id);
    }
}
