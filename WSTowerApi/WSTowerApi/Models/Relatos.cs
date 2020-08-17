﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace WSTowerApi.Models
{
    public class Relatos
    {
        public int Id { get; set; }
        public  string Relato { get; set; }
        public  string Imagem { get; set; }
        public  decimal Latitude{ get; set; }
        public  decimal Longitude { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
