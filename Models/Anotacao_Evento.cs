using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Anotacao_Evento
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public int eventoId { get; set; }
        public Evento evento { get; set; }
    }
}
