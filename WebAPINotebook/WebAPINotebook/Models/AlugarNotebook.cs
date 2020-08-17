using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPINotebook.Models
{
    public class AlugarNotebook
    {
        
        public int Id { get; set; }

        public string NomeLocador { get; set; }

        public decimal ValorAluguel { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public bool EstaAlugado { get; set; }

        public int NotebookId { get; set; }

        public Notebook Notebook { get; set; }

    }
}
