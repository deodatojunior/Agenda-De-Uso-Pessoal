using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Anotacao_Lembrete
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public int lembreteId { get; set; }
        public Lembrete lembrete { get; set; }
    }
}
