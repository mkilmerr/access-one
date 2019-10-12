using System;

namespace AccessOne.Domain.Entities
{
    public class Comando : BaseEntity
    {
        public string ComandoStr { get; set; }
        public Computador Computador { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataExecucao { get; set; }
        public string Retorno { get; set; }
    }
}
