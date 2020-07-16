using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;

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

        public List<string> ObterPalavras()
        {
            var palavras = new List<string>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = Resource_Queries.SELECT_PALAVRAS;

                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetString(0);
                            palavras.Add(result);
                        }
                    }

                    transaction.Commit();
                }
            }

            return palavras;
        }

        public void RemoverPalavra()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCmd = connection.CreateCommand();
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
    }
}
