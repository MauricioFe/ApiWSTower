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
        Usuario Login(Usuario usuario);
    }
}
