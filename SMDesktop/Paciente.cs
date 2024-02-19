using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMDesktop.DadosHelper;

namespace SMDesktop
{
    public class Paciente
    {
        public string Nome { get; set; }      
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string CPF { get; set; }
        public string CIDHD { get; set; }
        public string Observacoes { get; set; }

        public bool EmiteReciboIR { get; set; }
        public bool EmiteReciboConvenio { get; set; }
        public bool EnviaMsgAniversario { get; set; }
        public bool EmiteRecibo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAniversario { get; set; }
        public string Erro { get; set; }



        public Paciente()
        {

        }

       
        public Paciente(string nome, string cpf, bool emiteReciboIR, bool emiteReciboConvenio, bool enviaMsgAniversario, bool emiteRecibo, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            EmiteReciboIR = emiteReciboIR;
            EmiteReciboConvenio = emiteReciboConvenio;
            EnviaMsgAniversario = enviaMsgAniversario;
            EmiteRecibo = emiteRecibo;
            Ativo = ativo;
        }

        public Paciente(string nome, string email, string whatsapp, string cpf, bool emitereciboIR, bool emiteReciboConvenio, bool enviaMsgAniversario, bool emiteRecibo, bool ativo, DateTime dataAniversario)
        {
            Nome = nome;            
            Email = email;
            Whatsapp = whatsapp;
            CPF = cpf;
            EmiteReciboIR = emitereciboIR;
            EmiteReciboConvenio = emiteReciboConvenio;
            EmiteRecibo = emiteRecibo;
            Ativo = ativo;
            DataAniversario = dataAniversario;
            EnviaMsgAniversario = enviaMsgAniversario;
        }

        public Paciente(string nome, string email, string whatsapp, string cpf, string cidhd, bool emiteReciboIR, bool emiteReciboConvenio, bool enviaMsgAniversario, bool emiteRecibo, bool ativo, DateTime dataAniversario)
        {
            Nome = nome;
            Email = email;
            Whatsapp = whatsapp;
            CPF = cpf;
            CIDHD = cidhd;
            EmiteReciboIR = emiteReciboIR;
            EmiteReciboConvenio = emiteReciboConvenio;
            EnviaMsgAniversario = enviaMsgAniversario;
            EmiteRecibo = emiteRecibo;
            Ativo = ativo;
            DataAniversario = dataAniversario;
        }

        public Paciente(string nome, string email, string whatsapp, string cpf, string cidhd, string observacoes, bool emiteReciboIR, bool emiteReciboConvenio, bool enviaMsgAniversario, bool emiteRecibo, bool ativo, DateTime dataAniversario)
        {
            Nome = nome;
            Email = email;
            Whatsapp = whatsapp;
            CPF = cpf;
            CIDHD = cidhd;
            Observacoes = observacoes;
            EmiteReciboIR = emiteReciboIR;
            EmiteReciboConvenio = emiteReciboConvenio;
            EnviaMsgAniversario = enviaMsgAniversario;
            EmiteRecibo = emiteRecibo;
            Ativo = ativo;
            DataAniversario = dataAniversario;
        }

        public DataTable CarregaPacientes()
        {

            return GetPacientes();

        }

        public DataTable CarregaAniversariantes()
        {
            return GetAniversariantes();
        }

        public Paciente CarregaPorCpf(string cpf)
        {
            return GetPaciente(cpf);
        }

        public bool PacienteExiste(string cpf)
        {
            try
            {
                if (GetCPF(cpf))
                {
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                Erro = ex.Message;
                return false;
            }
            catch(Exception ex)
            {
                Erro = ex.Message;
                return false;
            }
            
        }

        public bool CadastraPaciente(Paciente paciente)
        {
            try
            {
                if (Add(paciente))
                {
                    return true;
                }

                return false;
            }
            catch (SqlException ex)
            {
                Erro = ex.Message; return false;
            }
            catch (Exception ex)
            {
                Erro = ex.Message; return false;
            }

        }

        public bool AtualizaPaciente(Paciente paciente)
        {
            try
            {
                if (Update(paciente))
                { return true; }

                return false;
            }
            catch (SqlException ex)
            {
                Erro = ex.Message; return false;
            }
            catch (Exception ex)
            {
                Erro = ex.Message; return false;
            }

        }

        public bool ExcluiPaciente(string cpf)
        {
            if (Delete(cpf))
            {
                return true;
            }
            return false;
        }

        public DataTable CarregaPacientesAtivosComRecibo()
        {
            return GetPacientesAtivosEmitemRecibo();

        }

        public Paciente CarregaPacientePorNome(string nome)
        {
            return GetDadosPacientePorNome(nome);
        }
    }
}