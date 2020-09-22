using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeLetras.Repositorio
{
    public class MaterialRepositorio: RepositorioBase, IRepos
    {
        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Resource_Queries.MATERIAL_CREATE_TABLE;
                tableCmd.ExecuteNonQuery();
            }
        }

        private void VerificaInsereTodasAsLetras()
        {
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (Obter().Count == 0)
            {

                foreach (var letra in letras.ToCharArray())
                {
                    Inserir(new Material()
                    {
                        Descricao = letra.ToString(),
                        Quantidade = 0
                    });
                }
            }

        }

        internal void AlterarQuantidade(int idSelecionado, decimal value)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCmd = connection.CreateCommand();
                    updateCmd.Parameters.AddWithValue("@id", idSelecionado);
                    updateCmd.Parameters.AddWithValue("@quantidade", value);
                    updateCmd.CommandText = Resource_Queries.MATERIAL_UPDATE_QUANTIDADE;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public List<Material> Obter()
        {
            var letras = new List<Material>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.MATERIAL_SELECT;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        letras.Add(new Material() {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                            Quantidade = reader.GetInt32(2)
                            });
                    }
                }
            }

            return letras;
        }

        public List<Material> ObterPorId(int id)
        {
            var letras = new List<Material>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.MATERIAL_SELECT_POR_ID;
                selectCmd.Parameters.Add(new SqliteParameter("@id", id));

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        letras.Add(new Material() {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                            Quantidade = reader.GetInt32(2)
                            });
                    }
                }
            }

            return letras;
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
                    deleteCmd.CommandText = Resource_Queries.MATERIAL_DELETE;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public void Inserir(Material letra)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.Parameters.Add(new SqliteParameter("@descricao", letra.Descricao));
                    insertCmd.Parameters.Add(new SqliteParameter("@quantidade", letra.Quantidade));
                    insertCmd.CommandText = Resource_Queries.MATERIAL_INSERT;
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void Alterar(Material letra)
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
                    updateCmd.CommandText = Resource_Queries.MATERIAL_UPDATE;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
