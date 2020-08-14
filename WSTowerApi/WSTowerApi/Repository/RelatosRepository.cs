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
        public void Add(Relato relato)
        {
            _context.Relatos.Add(relato);
            _context.SaveChanges();
        }

        public Relato Find(int id)
        {
            return _context.Relatos.Include(r => r.Usuario).FirstOrDefault(r => r.Id == id);          
        }

        public IEnumerable<Relato> GetAll()
        {
            return _context.Relatos.ToList();
        }

        public void Remove(int id)
        {
            var relato = Find(id);
            _context.Relatos.Remove(relato);
            _context.SaveChanges();
        }

        public void Update(Relato relato)
        {
            _context.Relatos.Update(relato);
            _context.SaveChanges();
        }
    }
}
