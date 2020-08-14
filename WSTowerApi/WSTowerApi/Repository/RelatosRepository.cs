using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Data;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public class RelatosRepository : IRelatosRepository
    {
        private readonly WsTowerContext _context;

        public RelatosRepository(WsTowerContext context)
        {
            _context = context;
        }
        public void Add(Relatos relatos)
        {
            _context.Relatos.Add(relatos);
            _context.SaveChanges();
        }

        public Relatos Find(int id)
        {
            return _context.Relatos.Include(r => r.Usuario).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Relatos> GetAll()
        {
            return _context.Relatos.Include(r => r.Usuario).ToList();
        }

        public void Remove(int id)
        {
            var relatos = Find(id);
            _context.Relatos.Remove(relatos);
            _context.SaveChanges();
        }

        public void Update(Relatos relatos)
        {
            _context.Relatos.Update(relatos);
            _context.SaveChanges();
        }
    }
}
