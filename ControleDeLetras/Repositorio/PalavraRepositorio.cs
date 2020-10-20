using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using ControleDeLetras.Repositorio.Queries;
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
                tableCmd.CommandText = Resource_CRUD.PALAVRA_CREATE_TABLE;
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
                selectCmd.CommandText = Resource_CRUD.PALAVRA_SELECT;

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
                    deleteCmd.CommandText = Resource_CRUD.PALAVRA_DELETE;
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
                    insertCmd.CommandText = Resource_CRUD.PALAVRA_INSERT;
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
                    updateCmd.CommandText = Resource_CRUD.PALAVRA_UPDATE;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

    }
}
