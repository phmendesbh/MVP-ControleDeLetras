using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using ControleAdornos.Repositorio.Queries;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ControleDeLetras.Repositorio
{
    public class PalavraRepositorio: RepositorioBase, IRepos
    {
        public PalavraRepositorio()
        {
            VerificaBanco();
        }

        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Palavra_Queries.CriarTabelaPalavra;
                tableCmd.ExecuteNonQuery();
            }
        }

        public List<Palavra> Obter()
        {
            var lstPalavras = new List<Palavra>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Palavra_Queries.ObterPalavras;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstPalavras.Add(new Palavra(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }

            return lstPalavras;
        }

        internal void Remover(Palavra palavra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.Parameters.AddWithValue("@id", palavra.Id);
                    deleteCmd.CommandText = Palavra_Queries.ApagarPalavra;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void Inserir(string palavra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.Parameters.Add(new SqliteParameter("@descricao", palavra));
                    insertCmd.CommandText = Palavra_Queries.InserirPalavra;
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void Alterar(Palavra palavra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCmd = connection.CreateCommand();
                    updateCmd.Parameters.AddWithValue("@id", palavra.Id);
                    updateCmd.Parameters.AddWithValue("@descricao", palavra.Descricao);
                    updateCmd.CommandText = Palavra_Queries.AlterarPalavra;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

    }
}
