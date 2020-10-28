using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using ControleAdornos.Repositorio.Queries;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ControleDeLetras.Repositorio
{
    class CorRepositorio : RepositorioBase, IRepos
    {
        public CorRepositorio()
        {
            VerificaBanco();
        }

        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Cor_Queries.CriarTabelaCor;
                tableCmd.ExecuteNonQuery();
            }
        }

        public List<Cor> Obter()
        {
            var cores = new List<Cor>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Cor_Queries.ObterCores;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cores.Add(new Cor()
                        {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                            ValorARBG = reader.GetInt32(2)
                        });
                    }
                }
            }

            return cores;
        }

        public void Remover(int id)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.CommandText = Cor_Queries.ApagarCor;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public void Inserir(Cor cor)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.Parameters.Add(new SqliteParameter("@descricao", cor.Descricao));
                    insertCmd.Parameters.Add(new SqliteParameter("@valorARGB", cor.ValorARBG));
                    insertCmd.CommandText = Cor_Queries.InserirCor;
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void Alterar(Cor cor)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCmd = connection.CreateCommand();
                    updateCmd.Parameters.AddWithValue("@id", cor.Id);
                    updateCmd.Parameters.AddWithValue("@descricao", cor.Descricao);
                    updateCmd.Parameters.AddWithValue("@valorARGB", cor.ValorARBG);
                    updateCmd.CommandText = Cor_Queries.AlterarCor;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
