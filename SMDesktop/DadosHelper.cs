using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System;
using System.Data.SqlClient;

namespace SMDesktop
{
    public static class DadosHelper
    {
        private static SqlConnection sqlConnection;
        private static string sqlConnectionString = $"Data Source=G3B4RB4\\SQLEXPRESS; Initial Catalog=SMDESKPROD; Integrated Security = true";


        private static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        #region Pacientes
        public static DataTable GetPacientes()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM PACIENTES ORDER BY NOME";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAniversariantes()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM PACIENTES WHERE ENVIAMSGANIVERSARIO = 1 ORDER BY NOME";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAllPacientes(string cpf)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT * FROM PACIENTES WHERE CPF={0} ORDER BY NOME", cpf);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Paciente GetPaciente(string cpf)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            Paciente paciente = new Paciente();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT * FROM PACIENTES WHERE CPF={0} ORDER BY NOME", cpf);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    paciente.CPF = dt.Rows[0]["CPF"].ToString();
                    paciente.Nome = dt.Rows[0]["NOME"].ToString();
                    paciente.Email = dt.Rows[0]["EMAIL"].ToString();
                    paciente.Whatsapp = dt.Rows[0]["WHATSAPP"].ToString();
                    paciente.DataAniversario = (DateTime)dt.Rows[0]["DATAANIVERSARIO"];
                    paciente.Ativo = (bool)dt.Rows[0]["ATIVO"];
                    return paciente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool GetCPF(string cpf)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            Paciente paciente = new Paciente();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT CPF FROM PACIENTES WHERE CPF={0} ORDER BY NOME", cpf);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Add(Paciente paciente)
        {
            bool sucesso = false;

            if (paciente == null)
            {
                throw new Exception();
            }

            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO PACIENTES(NOME, EMAIL, WHATSAPP, CPF, EMITERECIBOIR, EMITERECIBOCONVENIO, EMITERECIBO, ATIVO, DATAANIVERSARIO, ENVIAMSGANIVERSARIO, CIDHD, OBSERV) VALUES (@Nome, @Email, @Whatsapp, @CPF, @EmiteReciboIR, @EmiteReciboConvenio, @EmiteRecibo, @Ativo, @DataAniversario, @EnviaMsgAniversario, @CIDHD, @Observacoes)";
                    cmd.Parameters.AddWithValue("@Nome", paciente.Nome);
                    cmd.Parameters.AddWithValue("@Email", paciente.Email);
                    cmd.Parameters.AddWithValue("@Whatsapp", paciente.Whatsapp);
                    cmd.Parameters.AddWithValue("@CPF", paciente.CPF);
                    cmd.Parameters.AddWithValue("@EmiteReciboIR", Convert.ToInt32(paciente.EmiteReciboIR));
                    cmd.Parameters.AddWithValue("@EmiteReciboConvenio", Convert.ToInt32(paciente.EmiteReciboConvenio));
                    cmd.Parameters.AddWithValue("@EmiteRecibo", Convert.ToInt32(paciente.EmiteRecibo));
                    cmd.Parameters.AddWithValue("@Ativo", Convert.ToInt32(paciente.Ativo));

                    if (paciente.DataAniversario == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@DataAniversario", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DataAniversario", paciente.DataAniversario);
                    }

                    cmd.Parameters.AddWithValue("@EnviaMsgAniversario", Convert.ToInt32(paciente.EnviaMsgAniversario));
                    cmd.Parameters.AddWithValue("@CIDHD", paciente.CIDHD);
                    cmd.Parameters.AddWithValue("@Observacoes", paciente.Observacoes);



                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        sucesso = true;
                    }

                    return sucesso;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static bool Update(Paciente paciente)
        {
            bool sucesso = false;
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    if (paciente == null)
                    {
                        throw new Exception();
                    }

                    cmd.CommandText = "UPDATE PACIENTES SET NOME = @Nome, EMAIL = @Email, WHATSAPP = @Whatsapp, EMITERECIBOIR = @EmiteReciboIR, EMITERECIBOCONVENIO = @EmiteReciboConvenio, EMITERECIBO = @EmiteRecibo, ATIVO = @Ativo, DATAANIVERSARIO = @DataAniversario, ENVIAMSGANIVERSARIO = @EnviaMsgAniversario, CIDHD = @CIDHD, OBSERV = @Observacoes WHERE CPF = @CPF";

                    cmd.Parameters.AddWithValue("@CPF", paciente.CPF);
                    cmd.Parameters.AddWithValue("@Nome", paciente.Nome);
                    cmd.Parameters.AddWithValue("@Email", paciente.Email);
                    cmd.Parameters.AddWithValue("@EmiteReciboIR", Convert.ToInt32(paciente.EmiteReciboIR));
                    cmd.Parameters.AddWithValue("@EmiteReciboConvenio", Convert.ToInt32(paciente.EmiteReciboConvenio));
                    cmd.Parameters.AddWithValue("@EmiteRecibo", Convert.ToInt32(paciente.EmiteRecibo));
                    cmd.Parameters.AddWithValue("@Ativo", Convert.ToInt32(paciente.Ativo));

                    if (paciente.DataAniversario == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@DataAniversario", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DataAniversario", paciente.DataAniversario);
                    }


                    cmd.Parameters.AddWithValue("@EnviaMsgAniversario", Convert.ToInt32(paciente.EnviaMsgAniversario));
                    cmd.Parameters.AddWithValue("@Whatsapp", paciente.Whatsapp);
                    cmd.Parameters.AddWithValue("@CIDHD", paciente.CIDHD);
                    cmd.Parameters.AddWithValue("@Observacoes", paciente.Observacoes);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        sucesso = true;
                    }

                    return sucesso;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static bool Delete(string cpf)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM PACIENTES Where CPF=@CPF";
                    cmd.Parameters.AddWithValue("@CPF", cpf);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetPacientesAtivosEmitemRecibo()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT * FROM PACIENTES WHERE ATIVO = 1 AND EMITERECIBO = 1 ORDER BY NOME");
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Paciente GetDadosPacientePorNome(string nome)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            Paciente paciente = new Paciente();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT * FROM PACIENTES WHERE NOME = '{0}' ", nome);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);


                    foreach (DataRow dtrow in dt.Rows)
                    {
                        paciente.CPF = dtrow["CPF"].ToString();
                        paciente.CIDHD = dtrow["CIDHD"].ToString();
                        paciente.Observacoes = dtrow["OBSERV"].ToString();


                        if (dtrow["DATAANIVERSARIO"] == DBNull.Value)
                        {
                            paciente.DataAniversario = DateTime.MinValue;
                        } else
                        {
                            paciente.DataAniversario = DateTime.Parse(dtrow["DATAANIVERSARIO"].ToString());
                        }
                        
                        paciente.EmiteReciboIR = (bool)dtrow["EMITERECIBOIR"];
                        paciente.EmiteReciboConvenio = (bool)dtrow["EMITERECIBOCONVENIO"];
                        paciente.Ativo = (bool)dtrow["ATIVO"];
                        paciente.Email = dtrow["EMAIL"].ToString();
                        paciente.EmiteRecibo = (bool)dtrow["EMITERECIBO"];
                        paciente.EnviaMsgAniversario = (bool)dtrow["ENVIAMSGANIVERSARIO"];
                        paciente.Whatsapp = dtrow["WHATSAPP"].ToString();
                        paciente.Nome = dtrow["NOME"].ToString();

                    }

                    return paciente;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion

        #region Recibos
        public static DataTable GetRecibos()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM RECIBOS";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllRecibos(string cpf)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT * FROM RECIBOS WHERE CPFPACI='{0}' ORDER BY DTCONSULTA DESC", cpf);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetRecibosPeriodo(DateTime periodo)
        {
            var periodoDe = new DateTime(periodo.Year, periodo.Month, 1);
            var periodoAte = periodoDe.AddMonths(1).AddDays(-1);

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT CPFPACI,NOMEPACI,VALOR,VALOREXT,FORMAT (DTEMIS, 'dd/MM/yyyy ') as DTEMIS,FORMAT (DTNASC, 'dd/MM/yyyy ') as DTNASC FROM RECIBOS WHERE DTEMIS >='{0}' AND DTEMIS <='{1}' ORDER BY NOMEPACI,DTEMIS;", periodoDe,periodoAte);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal GetTotalPeriodo(DateTime periodo)
        {
            var periodoDe = new DateTime(periodo.Year, periodo.Month, 1);
            var periodoAte = periodoDe.AddMonths(1).AddDays(-1);
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            decimal valortotalperiodo = 0;
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT  sum(CAST(VALOR AS decimal(18,2))) AS VALORPERIODO FROM RECIBOS WHERE DTEMIS BETWEEN '{0}' AND '{1}';", periodoDe,periodoAte);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);

                    for(int i =0; i < dt.Rows.Count; i++)
                    {
                        valortotalperiodo = dt.Rows[i].Field<decimal>("VALORPERIODO");
                    }

                    return valortotalperiodo;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static Recibo GetRecibo(string cpf)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            Recibo recibo = new Recibo();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT * FROM RECIBOS WHERE CPFPACI={0} ORDER BY DTCONSULTA DESC", cpf);
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    recibo.ID = (int)dt.Rows[0]["ID"];
                    recibo.CPFPaciente = dt.Rows[0]["CPFPACI"].ToString();
                    recibo.NomePaciente = dt.Rows[0]["NOMEPACI"].ToString();
                    recibo.ValorExtenso = dt.Rows[0]["VALOREXT"].ToString();
                    recibo.Valor = (decimal)dt.Rows[0]["VALOR"];
                    recibo.DataNascPaciente = (DateTime)dt.Rows[0]["DTNASC"];
                    recibo.DataEmissao = (DateTime)dt.Rows[0]["DTEMIS"];
                    recibo.DataConsulta = (DateTime)dt.Rows[0]["DTCONSULTA"];
                    recibo.CIDHDPaciente = dt.Rows[0]["CIDHD"].ToString();
                    return recibo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddRecibo(Recibo recibo)
        {
            bool sucesso = false;

            if (recibo == null)
            {
                throw new Exception();
            }

            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO RECIBOS(CPFPACI,VALOR,VALOREXT,DTCONSULTA,DTEMIS,DTNASC,CIDHD,NOMEPACI ) values (@CPFPaciente, @Valor, @ValorExtenso, @DataConsulta,@DataEmissao, @DataNascPaciente, @CIDHD, @NomePaci)";
                    cmd.Parameters.AddWithValue("@CPFPaciente", recibo.CPFPaciente);
                    cmd.Parameters.AddWithValue("@Valor", recibo.Valor);
                    cmd.Parameters.AddWithValue("@ValorExtenso", recibo.ValorExtenso);
                    cmd.Parameters.AddWithValue("@DataConsulta", recibo.DataConsulta);

                    if (recibo.DataEmissao == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@DataEmissao", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DataEmissao", recibo.DataEmissao);
                    }



                    if (recibo.DataNascPaciente == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@DataNascPaciente", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DataNascPaciente", recibo.DataNascPaciente);
                    }

                    cmd.Parameters.AddWithValue("@CIDHD", recibo.CIDHDPaciente);
                    cmd.Parameters.AddWithValue("@NomePaci", recibo.NomePaciente);



                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        sucesso = true;
                    }

                    return sucesso;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool UpdateRecibo(Recibo recibo)
        {
            bool sucesso = false;
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    if (recibo == null)
                    {
                        throw new Exception();
                    }

                    cmd.CommandText = "UPDATE RECIBOS SET CPFPACI = @CPFPaciente, VALOR = @Valor, VALOREXT = @ValorExtenso, DTCONSULTA = @DataConsulta, DTEMIS = @DataEmissao, DTNASC = @DataNascPaciente, CIDHD = @CIDHD, NOMEPACI = @NomePaciente";

                    cmd.Parameters.AddWithValue("@CPFPaciente", recibo.CPFPaciente);
                    cmd.Parameters.AddWithValue("@Valor", recibo.Valor);
                    cmd.Parameters.AddWithValue("@ValorExtenso", recibo.ValorExtenso);
                    cmd.Parameters.AddWithValue("@DataConsulta", recibo.DataConsulta);
                    cmd.Parameters.AddWithValue("@DataEmissao", recibo.DataEmissao);
                    cmd.Parameters.AddWithValue("@DataNascPaciente", recibo.DataNascPaciente);
                    cmd.Parameters.AddWithValue("@CIDHD", recibo.CIDHDPaciente);
                    cmd.Parameters.AddWithValue("@NomePaci", recibo.NomePaciente);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        sucesso = true;
                    }

                    return sucesso;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool DeleteAllRecibos(string cpf)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM RECIBOS Where CPFPACI=@CPFPaciente";
                    cmd.Parameters.AddWithValue("@CPFPaciente", cpf);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteRecibo(string cpf, string idRecibo)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM RECIBOS Where CPFPACI=@CPFPaciente AND ID =@Id";
                    cmd.Parameters.AddWithValue("@CPFPaciente", cpf);
                    cmd.Parameters.AddWithValue("@Id", idRecibo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion
    }
}

