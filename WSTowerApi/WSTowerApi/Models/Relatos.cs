using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowerApi.Models
{
    public class Relatos
    {
        public int id { get; set; }
        public string relato { get; set; }
        public string imagem { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int usuario_id { get; set; }
        [ForeignKey("id")]
        public Usuario usuario { get; set; }
    }
}
