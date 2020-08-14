using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Data;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly WsTowerContext _context;

        public UsuarioRepository(WsTowerContext context)
        {
            _context = context;
        }
        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario Find(int id)
        {
            return _context.Usuario.Include(u => u.Funcao).FirstOrDefault(f => f.Id == id);
            
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario.Include(u => u.Funcao).ToList();
        }

        public void Remove(int id)
        {
            var usuario = Find(id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
