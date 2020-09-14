using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeLetras.Repositorio
{
    public class LetraRepositorio: IRepos
    {
        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Resource_Queries.CREATE_TABLE_LETRA;
                tableCmd.ExecuteNonQuery();
            }
        }

        public SqliteConnectionStringBuilder CriaConexao()
        {
            var conexao = new SqliteConnectionStringBuilder
            {
                DataSource = "./palavrasDb.db"
            };

            return conexao;
        }

        public List<Letra> Obter()
        {
            var letras = new List<Letra>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.SELECT_LETRA;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        letras.Add(new Letra() {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                            Quantidade = reader.GetInt32(2)
                            });
                    }
                }
            }

            return letras;
        }

        public List<Letra> ObterPorId(int id)
        {
            var letras = new List<Letra>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.SELECT_LETRA_POR_ID;
                selectCmd.Parameters.Add(new SqliteParameter("@id", id));

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        letras.Add(new Letra() {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                            Quantidade = reader.GetInt32(2)
                            });
                    }
                }
            }

            return letras;
        }

        public void Remover(Letra letra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.Parameters.AddWithValue("@id", letra.Id);
                    deleteCmd.CommandText = Resource_Queries.DELETE_LETRA;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public void Inserir(Letra letra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.Parameters.Add(new SqliteParameter("@descricao", letra.Descricao));
                    insertCmd.Parameters.Add(new SqliteParameter("@quantidade", letra.Quantidade));
                    insertCmd.CommandText = Resource_Queries.INSERT_LETRA;
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void AlterarQuantidade(Letra letra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCmd = connection.CreateCommand();
                    updateCmd.Parameters.AddWithValue("@id", letra.Id);
                    updateCmd.Parameters.AddWithValue("@quantidade", letra.Quantidade);
                    updateCmd.CommandText = Resource_Queries.UPDATE_LETRA_QUANTIDADE;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void Alterar(Letra letra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCmd = connection.CreateCommand();
                    updateCmd.Parameters.AddWithValue("@id", letra.Id);
                    updateCmd.Parameters.AddWithValue("@descricao", letra.Descricao);
                    updateCmd.Parameters.AddWithValue("@quantidade", letra.Quantidade);
                    updateCmd.CommandText = Resource_Queries.UPDATE_LETRA;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
