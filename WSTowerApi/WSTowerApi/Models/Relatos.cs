using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowerApi.Models
{
    public class Relatos
    {
        public int Id { get; set; }
        public string Relato { get; set; }
        public string Imagem { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Usuario_id { get; set; }
        [ForeignKey("id")]
        public Usuario Usuario { get; set; }
    }
}
