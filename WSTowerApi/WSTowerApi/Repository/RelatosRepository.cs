using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Data;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public class RelatoRepository : IRelatoRepository
    {
        private readonly WsTowerContext _context;

        public RelatoRepository(WsTowerContext context)
        {
            _context = context;
        }

        public void Add(Relatos relato)
        {
            _context.Relatos.Add(relato);
            _context.SaveChanges();
        }

        public Relatos Find(int id)
        {
            return _context.Relatos.Include(u => u.Usuario).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Relatos> GetAll()
        {
            return _context.Relatos.Include(u => u.Usuario).ToList();
        }

        public void Remove(int id)
        {
            var relato = Find(id);
            _context.Relatos.Remove(relato);
            _context.SaveChanges();
        }

        public void Update(Relatos relato)
        {
            _context.Relatos.Update(relato);
            _context.SaveChanges();
        }
    }
}
