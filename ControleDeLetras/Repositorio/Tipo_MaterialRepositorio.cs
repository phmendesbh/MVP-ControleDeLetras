using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ControleDeLetras.Repositorio
{
    class Tipo_MaterialRepositorio : RepositorioBase, IRepos
    {
        public Tipo_MaterialRepositorio()
        {
            VerificaBanco();
        }

        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Resource_Queries.TIPO_MATERIAL_CREATE_TABLE;
                tableCmd.ExecuteNonQuery();
            }
        }

        public List<Tipo_Material> Obter()
        {
            var tipo_Materiais = new List<Tipo_Material>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.TIPO_MATERIAL_SELECT;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipo_Materiais.Add(new Tipo_Material()
                        {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                        });
                    }
                }
            }

            return tipo_Materiais;
        }

        public List<Tipo_Material> ObterPorId(int id)
        {
            var tipo_Materiais = new List<Tipo_Material>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.TIPO_MATERIAL_SELECT_POR_ID;
                selectCmd.Parameters.Add(new SqliteParameter("@id", id));

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipo_Materiais.Add(new Tipo_Material()
                        {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                        });
                    }
                }
            }

            return tipo_Materiais;
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
                    deleteCmd.CommandText = Resource_Queries.TIPO_MATERIAL_DELETE;
                    deleteCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public void Inserir(Tipo_Material tipo_Material)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();
                    insertCmd.Parameters.Add(new SqliteParameter("@descricao", tipo_Material.Descricao));
                    insertCmd.CommandText = Resource_Queries.TIPO_MATERIAL_INSERT;
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        internal void Alterar(Tipo_Material tipo_Material)
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCmd = connection.CreateCommand();
                    updateCmd.Parameters.AddWithValue("@id", tipo_Material.Id);
                    updateCmd.Parameters.AddWithValue("@descricao", tipo_Material.Descricao);
                    updateCmd.CommandText = Resource_Queries.TIPO_MATERIAL_UPDATE;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
