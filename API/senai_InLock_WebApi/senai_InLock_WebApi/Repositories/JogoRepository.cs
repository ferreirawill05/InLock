using senai_InLock_WebApi.Domains;
using senai_InLock_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //private string stringConexao = @"Data Source=NOTE0113C5\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"Data Source=MARCAUM\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=senai@132";
        private string stringConexao = @"Data Source=LAPTOP-BSMJ3RKB\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=senai@132;";
        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        {
            if(jogoAtualizado.nomeJogo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE jogos SET nomeJogo = @NovoNomeJogo WHERE idJogos = @idJogoAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@NovoNomeJogo", jogoAtualizado.nomeJogo);
                        cmd.Parameters.AddWithValue("@idJogoAtualizado", jogoAtualizado.idJogo);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idJogo, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE jogos SET nomeJogo = @novoNomeJogo WHERE idJogos = @idJogoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@idJogoAtualizado", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idJogos, nomeJogo, descricao, dataLancamento, valor, e.idEstudio, nomeEstudio FROM jogos INNER JOIN estudio e ON jogos.idEstudio = e.idEstudio WHERE idJogos = @idJogo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogos"]),
                            nomeJogo = reader["nomeJogo"].ToString(),
                            descricao = reader["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),
                            valor = Convert.ToDouble(reader["valor"]),
                            Estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(reader["idEstudio"]),
                                nomeEstudio = reader["nomeEstudio"].ToString()
                            },
                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            };
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO jogos (nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.Estudio.idEstudio);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM jogos WHERE idJogos = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectAll = "SELECT idJogos, nomeJogo, descricao, dataLancamento, valor, e.idEstudio, nomeEstudio FROM jogos INNER JOIN estudio e ON jogos.idEstudio = e.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            nomeJogo = rdr[1].ToString(),
                            descricao = rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDouble(rdr[4]),
                            Estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(rdr[5]),
                                nomeEstudio = rdr[6].ToString()
                            },
                        };
                        ListaJogos.Add(jogo);
                    }
                }
            };
            return ListaJogos;
        }
    }
}
