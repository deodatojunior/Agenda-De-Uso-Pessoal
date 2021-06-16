using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Evento
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime data_evento { get; set; }
        public List<Anotacao_Evento> Anotacoes { get; set; }

    }
}
