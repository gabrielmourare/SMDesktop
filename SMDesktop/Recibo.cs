using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMDesktop.DadosHelper;

namespace SMDesktop
{
    public class Recibo
    {
        public int ID { get; set; }
        public string CPFPaciente { get; set; }
        public string NomePaciente { get; set; }
        public decimal Valor { get; set; }
        public string ValorExtenso { get; set; }       
        public DateTime DataConsulta { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataNascPaciente { get; set; }
        public string CIDHDPaciente { get; set; }

        public Recibo() { }

        public Recibo(string cPFPaciente, string nomePaciente, decimal valor, string valorExtenso, DateTime datasConsultas, DateTime dataEmissao)
        {
            CPFPaciente = cPFPaciente;
            NomePaciente = nomePaciente;
            Valor = valor;
            ValorExtenso = valorExtenso;
            DataConsulta = datasConsultas;
            DataEmissao = dataEmissao;
        }

        public Recibo(string cPFPaciente, string nomePaciente, decimal valor, string valorExtenso, DateTime datasConsultas, DateTime dataEmissao, DateTime dataNascPaciente, string cIDHD)
        {
            CPFPaciente = cPFPaciente;
            NomePaciente = nomePaciente;
            Valor = valor;
            ValorExtenso = valorExtenso;
            DataConsulta = datasConsultas;
            DataEmissao = dataEmissao;
            DataNascPaciente = dataNascPaciente;
            CIDHDPaciente = cIDHD;
        }

        public bool GravaRecibo(Recibo recibo)
        {
            if (!AddRecibo(recibo))
            {
                return false;
            }

            return true;
        }

        public DataTable CarregaRecibosPaciente(string cpf)
        {
            DataTable dt = GetAllRecibos(cpf);

            return dt;

        }

        public DataTable CarregaRecibosPeriodo(DateTime periodo)
        {
            DataTable dt = GetRecibosPeriodo(periodo);

            return dt;

        }

        public decimal CarregaTotalPeriodo(DateTime periodo)
        {
            decimal total = GetTotalPeriodo(periodo);
            return total;
        }

        public bool ExcluiRecibo(string cpf, string id)
        {
            if(!DeleteRecibo(cpf,id))
            {
                return false;
            }
            return true;
        }
    }
}
