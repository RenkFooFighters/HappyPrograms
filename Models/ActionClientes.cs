using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgendaTelefonica.Models.Entidades;
using System.Data.SqlClient;

namespace AgendaTelefonica.Models
{
    public class ActionClientes : GenericAbstractEntidades<Clientes, int>
    {
        #region DECLARAÇÃO DE VARIÁVEIS
        //Definindo a conexão com o banco
        private SqlConnection conn = new SqlConnection(ConexaoBanco.connString);
        //Objeto para comparação no input dos dados
        private object IIf(bool expression, object truePart, object falsePart)
        { return expression ? truePart : falsePart; }
        #endregion

        #region MÉTODOS SOBRESCRITOS
        //REALIZA CADASTRO DO CLIENTE NO BANCO DE DADOS 
        public override void Cadastrar(Clientes entity)
        {
            //Define o cmd e parâmetros
            SqlCommand cmd = new SqlCommand("P_CADASTRA_CLIENTE", conn);
            cmd.CommandTimeout = 7200;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RazaoSocial", IIf(string.IsNullOrEmpty(entity.RazaoSocial), "", entity.RazaoSocial));
            cmd.Parameters.AddWithValue("@NomeFantasia", IIf(string.IsNullOrEmpty(entity.NomeFantasia), "", entity.NomeFantasia));
            cmd.Parameters.AddWithValue("@CNPJ", IIf(string.IsNullOrEmpty(entity.CNPJ), "", entity.CNPJ));
            cmd.Parameters.AddWithValue("@DDD", IIf(string.IsNullOrEmpty(entity.DDD), "", entity.DDD));
            cmd.Parameters.AddWithValue("@TelefoneCorporativo", IIf(string.IsNullOrEmpty(entity.TelefoneCorporativo), "", entity.TelefoneCorporativo));
            cmd.Parameters.AddWithValue("@TelefoneCelCorporativo", IIf(string.IsNullOrEmpty(entity.TelefoneCelCorporativo), "", entity.TelefoneCelCorporativo));
            cmd.Parameters.AddWithValue("@Email", IIf(string.IsNullOrEmpty(entity.Email), "", entity.Email));
            cmd.Parameters.AddWithValue("@Logradouro", IIf(string.IsNullOrEmpty(entity.Logradouro), "", entity.Logradouro));
            cmd.Parameters.AddWithValue("@Endereco", IIf(string.IsNullOrEmpty(entity.Endereco), "", entity.Endereco));
            cmd.Parameters.AddWithValue("@Numero", IIf(string.IsNullOrEmpty(entity.Numero), "", entity.Numero));
            cmd.Parameters.AddWithValue("@Complemento", IIf(string.IsNullOrEmpty(entity.Complemento), "", entity.Complemento));
            cmd.Parameters.AddWithValue("@CEP", IIf(string.IsNullOrEmpty(entity.CEP), "", entity.CEP));
            cmd.Parameters.AddWithValue("@Bairro", IIf(string.IsNullOrEmpty(entity.Bairro), "", entity.Bairro));
            cmd.Parameters.AddWithValue("@Cidade", IIf(string.IsNullOrEmpty(entity.Cidade), "", entity.Cidade));
            cmd.Parameters.AddWithValue("@UF", IIf(string.IsNullOrEmpty(entity.UF), "", entity.UF));

            try
            {
                conn.Open();

                //EXECUTA SQL
                cmd.ExecuteNonQuery();
            }            
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //FECHA CONEXÃO
                conn.Close();
            }
        }

        //DELETA TODOS OS CLIENTES (FUNÇÃO DESABILITADA)
        public override void Deletar(Clientes entity)
        {
            //Define o cmd e parâmetros
            SqlCommand cmd = new SqlCommand("P_DELETA_CLIENTE", conn);
            cmd.CommandTimeout = 7200;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", entity.Id);

            try
            {
                conn.Open();

                //EXECUTA SQL
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //FECHA CONEXÃO
                conn.Close();
            }

        }

        //DELETA UM CLIENTE EM ESPECÍFICO
        public override void DeletarById(int id)
        {
            //Define o cmd e parâmetros
            SqlCommand cmd = new SqlCommand("P_DELETA_CLIENTE", conn);
            cmd.CommandTimeout = 7200;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                conn.Open();
                //EXECUTA SQL
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //FECHA CONEXÃO
                conn.Close();
            }
        }

        //ATUALIZA AS INFORMAÇÕES DO CLIENTE
        public override void Update(Clientes entity)
        {
            //Define o cmd e parâmetros
            SqlCommand cmd = new SqlCommand("P_UPDATE_CLIENTE", conn);
            cmd.CommandTimeout = 7200;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", entity.Id);
            cmd.Parameters.AddWithValue("@RazaoSocial", IIf(string.IsNullOrEmpty(entity.RazaoSocial), "", entity.RazaoSocial));
            cmd.Parameters.AddWithValue("@NomeFantasia", IIf(string.IsNullOrEmpty(entity.NomeFantasia), "", entity.NomeFantasia));
            cmd.Parameters.AddWithValue("@CNPJ", IIf(string.IsNullOrEmpty(entity.CNPJ), "", entity.CNPJ));
            cmd.Parameters.AddWithValue("@DDD", IIf(string.IsNullOrEmpty(entity.DDD), "", entity.DDD));
            cmd.Parameters.AddWithValue("@TelefoneCorporativo", IIf(string.IsNullOrEmpty(entity.TelefoneCorporativo), "", entity.TelefoneCorporativo));
            cmd.Parameters.AddWithValue("@TelefoneCelCorporativo", IIf(string.IsNullOrEmpty(entity.TelefoneCelCorporativo), "", entity.TelefoneCelCorporativo));
            cmd.Parameters.AddWithValue("@Email", IIf(string.IsNullOrEmpty(entity.Email), "", entity.Email));
            cmd.Parameters.AddWithValue("@Logradouro", IIf(string.IsNullOrEmpty(entity.Logradouro), "", entity.Logradouro));
            cmd.Parameters.AddWithValue("@Endereco", IIf(string.IsNullOrEmpty(entity.Endereco), "", entity.Endereco));
            cmd.Parameters.AddWithValue("@Numero", IIf(string.IsNullOrEmpty(entity.Numero), "", entity.Numero));
            cmd.Parameters.AddWithValue("@Complemento", IIf(string.IsNullOrEmpty(entity.Complemento), "", entity.Complemento));
            cmd.Parameters.AddWithValue("@CEP", IIf(string.IsNullOrEmpty(entity.CEP), "", entity.CEP));
            cmd.Parameters.AddWithValue("@Bairro", IIf(string.IsNullOrEmpty(entity.Bairro), "", entity.Bairro));
            cmd.Parameters.AddWithValue("@Cidade", IIf(string.IsNullOrEmpty(entity.Cidade), "", entity.Cidade));
            cmd.Parameters.AddWithValue("@UF", IIf(string.IsNullOrEmpty(entity.UF), "", entity.UF));

            try
            {
                conn.Open();
                //Executa SQL
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
                
            }
            finally
            {
                conn.Close();
            }
        }

        //PEGA TODOS OS DADOS
        public override List<Clientes> GetAll()
        {
            //Define o cmd e parâmetros
            SqlCommand cmd = new SqlCommand("P_CONSULTA_DADOS_CLIENTE", conn);
            cmd.CommandTimeout = 7200;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", "");
            cmd.Parameters.AddWithValue("@CNPJ", "");
            SqlDataReader rdr;
            Clientes c = null;

            List<Clientes> list = new List<Clientes>();

            try
            {
                conn.Open();

                //Executa SQL
                rdr = cmd.ExecuteReader();

                //Inicia leitura
                while (rdr.Read())
                {
                    //Inputa os dados na entidade.
                    c = new Clientes();
                    c.Id = (int)rdr["ID"];
                    c.RazaoSocial = rdr["RazaoSocial"].ToString();
                    c.NomeFantasia = rdr["NomeFantasia"].ToString();
                    c.CNPJ = rdr["CNPJ"].ToString();
                    c.Id_Contato = (int)rdr["ID_CLI"];
                    c.DDD = rdr["DDD"].ToString();
                    c.TelefoneCorporativo = rdr["TelefoneCorporativo"].ToString();
                    c.TelefoneCelCorporativo = rdr["TelefoneCelCorporativo"].ToString();
                    c.Email = rdr["Email"].ToString();
                    c.Id_Endereco = (int)rdr["ID_CLI"];
                    c.Logradouro = rdr["Logradouro"].ToString();
                    c.Endereco = rdr["Endereco"].ToString();
                    c.Numero = rdr["Numero"].ToString();
                    c.Complemento = rdr["Complemento"].ToString();
                    c.CEP = rdr["CEP"].ToString();
                    c.Bairro = rdr["Bairro"].ToString();
                    c.Cidade = rdr["Cidade"].ToString();
                    c.UF = rdr["UF"].ToString();
                    list.Add(c);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            //Retorna a lista
            return list;
        }

        //PEGA UM CLIENTE ESPECÍFICO (GET)
        public override Clientes GetById(int id)
        {
            //Define o cmd e parâmetros
            SqlCommand cmd = new SqlCommand("P_CONSULTA_DADOS_CLIENTE", conn);
            cmd.CommandTimeout = 7200;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@CNPJ", "");

            Clientes c = null;
            SqlDataReader rdr;

            try
            {
                conn.Open();

                //Traz as informações de acordo com o id de parâmetro
                rdr = cmd.ExecuteReader();

                //Lê os dados que estão contidos no banco 
                if (rdr.HasRows)
                {
                    //Inicia leitura
                    if (rdr.Read())
                    {
                        //Inputa os dados na entidade.
                        c = new Clientes();
                        c.Id = (int)rdr["ID"];
                        c.RazaoSocial = rdr["RazaoSocial"].ToString();
                        c.NomeFantasia = rdr["NomeFantasia"].ToString();
                        c.CNPJ = rdr["CNPJ"].ToString();
                        c.Id_Contato = (int)rdr["ID_CLI"];
                        c.DDD = rdr["DDD"].ToString();
                        c.TelefoneCorporativo = rdr["TelefoneCorporativo"].ToString();
                        c.TelefoneCelCorporativo = rdr["TelefoneCelCorporativo"].ToString();
                        c.Email = rdr["Email"].ToString();
                        c.Id_Endereco = (int)rdr["ID_CLI"];
                        c.Logradouro = rdr["Logradouro"].ToString();
                        c.Endereco = rdr["Endereco"].ToString();
                        c.Numero = rdr["Numero"].ToString();
                        c.Complemento = rdr["Complemento"].ToString();
                        c.CEP = rdr["CEP"].ToString();
                        c.Bairro = rdr["Bairro"].ToString();
                        c.Cidade = rdr["Cidade"].ToString();
                        c.UF = rdr["UF"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                
                throw e;
            }
            finally
            {
                //Fecha conexão
                conn.Close();
            }

            //Retorna entity
            return c;
            
        }
        #endregion

    }
}