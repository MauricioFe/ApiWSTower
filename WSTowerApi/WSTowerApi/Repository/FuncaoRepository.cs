using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Data;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public class FuncaoRepository : IFuncaoRepository
    {
        private readonly WsTowerContext _context;

        public FuncaoRepository(WsTowerContext context)
        {
            _context = context;
        }

        public Funcao Find(int id)
        {
            return _context.Funcao.FirstOrDefault(f => f.Id== id);
        }

        public IEnumerable<Funcao> GetAll()
        {
            return _context.Funcao.ToList() ;
        }
    }
}
