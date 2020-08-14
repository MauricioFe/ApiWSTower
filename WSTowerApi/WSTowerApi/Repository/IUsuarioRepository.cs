using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario Find(int id);
        void Add(Usuario Usuario);
        void Update(Usuario Usuario);
        void Remove(int id);
    }
}
