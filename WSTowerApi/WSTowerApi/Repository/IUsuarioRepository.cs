using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Repository
{
    interface IUsuarioRepository
    {
        Usuario Find(int id);
        void Login(Usuario usuario);
    }
}
