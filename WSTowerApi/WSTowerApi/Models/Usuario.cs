﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WSTowerApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string  Email { get; set; }
        public string  Telefone { get; set; }
        public string  Senha { get; set; }
        public int FuncaoId { get; set; }
        public Funcao  Funcao { get; set; }
    }
}
