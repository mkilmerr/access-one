using System.Collections.Generic;

namespace AccessOne.Domain.Entities
{
    public class Computador : BaseEntity
    {
        public string Nome { get; set; }
        public string Ip { get; set; }
        public int EspacoEmDisco { get; set; }
        public int MemoriaDisponivel { get; set; }
        public Grupo Grupo { get; set; }
        public ICollection<Comando> Comandos { get; set; }
    }
}
