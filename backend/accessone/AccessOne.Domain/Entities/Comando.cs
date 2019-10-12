using System;
using System.Collections.Generic;
using System.Text;

namespace AccessOne.Domain.Entities
{
    public class Comando : BaseEntity
    {
        public Comando(string comandoStr, Computador computador, DateTime dataExecucao)
        {
            ComandoStr = comandoStr;
            Computador = computador;
            DataRegistro = DateTime.Now;
            DataExecucao = dataExecucao;
        }
        public string ComandoStr { get; set; }
        public Computador Computador { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataExecucao { get; set; }
    }
}
