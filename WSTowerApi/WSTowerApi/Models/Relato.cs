﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowerApi.Models
{
    public class Relato
    {
        public int Id { get; set; }
        public int relato { get; set; }
        public string Imagem{ get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
    }
}