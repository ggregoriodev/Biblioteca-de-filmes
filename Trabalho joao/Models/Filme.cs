using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_joao.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AnoLancamento { get; set; }
        public string Diretor { get; set; }
        public int UsuarioId { get; set; }

        
    }
}
