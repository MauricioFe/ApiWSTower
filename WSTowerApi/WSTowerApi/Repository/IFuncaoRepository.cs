using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public interface IFuncaoRepository
    {
        IEnumerable<Funcao> GetAll();
        Funcao Find(int id);
    }
}
