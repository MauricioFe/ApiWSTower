using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    interface IFuncaoRepository
    {
        IEnumerable<Funcao> GetAll();
    }
}
