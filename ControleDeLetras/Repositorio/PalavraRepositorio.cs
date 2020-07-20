using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ControleDeLetras.Repositorio
{
    public class PalavraRepositorio
    {
        /// <summary>
        /// Se não existir o banco, cria ele e a tabela
        /// </summary>
        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Resource_Queries.CREATE_TABLE_PALAVRAS;
                tableCmd.ExecuteNonQuery();
            }
        }

        private SqliteConnectionStringBuilder CriaConexao()
        {
            var conexao = new SqliteConnectionStringBuilder
            {
                DataSource = "./palavrasDb.db"
            };

            return conexao;
        }

        public Dictionary<int,string> ObterPalavras()
        {
            var palavras = new Dictionary<int, string>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.SELECT_PALAVRAS;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        palavras.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }

            return palavras;
        }

        public void RemoverPalavra(int id)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.CommandText = Resource_Queries.DELETE_PALAVRAS;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public void InserirPalavra(string palavra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.Parameters.Add(new SqliteParameter("@descricao", palavra));
                    insertCmd.CommandText = Resource_Queries.INSERT_PALAVRAS;
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void AlterarPalavra(int id, string descricao)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.Parameters.AddWithValue("@descricao", descricao);
                    deleteCmd.CommandText = Resource_Queries.UPDATE_PALAVRAS;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
