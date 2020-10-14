using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario Find(int id);
        Usuario Login(Usuario usuario);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(int id);
    }
}
