using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AulaMobileCloud.Models
{
    public class Characters
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Raça { get; set; }
        public string Sexo { get; set; }
        public string Planeta { get; set; }
    }
}