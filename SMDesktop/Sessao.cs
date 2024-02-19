using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDesktop
{
    internal class Sessao
    {
        public DateTime DataSessao { get; set; }
        public Decimal Valor { get; set; }
               
        public Sessao(DateTime dataSessao, Decimal valor)
        {
            DataSessao = dataSessao;
            Valor = valor;

        }
    }
}
