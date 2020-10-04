using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using ControleDeLetras.Util;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ControleDeLetras.Repositorio
{
    public class MaterialRepositorio: RepositorioBase, IRepos
    {
        readonly Utils utils = new Utils();

        public void VerificaBanco()
        {
            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = Resource_Queries.MATERIAL_CREATE_TABLE;
                tableCmd.ExecuteNonQuery();
            }

            VerificaInsereTodasAsLetras();
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
                        Tipo_Material_Id = 1,
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
                selectCmd.CommandText = Resource_Queries.MATERIAL_SELECT_JOIN_TIPO_MATERIAL;

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        letras.Add(new Material() {
                            Id = reader.GetInt32(0),
                            Descricao = reader.GetString(1),
                            Tipo_Material_Id = reader.GetInt32(2),
                            Tipo_Material_Descricao = reader.GetString(3),
                            Quantidade = reader.GetInt32(4)
                        });; ;
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

        internal void AtualizaEstoqueLetras(Palavra palavra)
        {
            var letras = Obter();
            var qtdeLetras = utils.CalculaQtdeLetras(new List<string>() { palavra.Descricao });

            foreach (KeyValuePair<string, int> qtdeLetra in qtdeLetras)
            {
                var letra = letras.Where(w => w.Descricao == qtdeLetra.Key).FirstOrDefault();
                AlterarQuantidade(letra.Id, qtdeLetra.Value * -1);
            };

            if (!string.IsNullOrWhiteSpace(palavra.DescricaoAntiga))
            {
                var qtdeLetrasAntigas = utils.CalculaQtdeLetras(new List<string>() { palavra.DescricaoAntiga });

                foreach (KeyValuePair<string, int> qtdeLetra in qtdeLetrasAntigas)
                {
                    var letra = letras.Where(w => w.Descricao == qtdeLetra.Key).FirstOrDefault();
                    AlterarQuantidade(letra.Id, qtdeLetra.Value);
                };
            }
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
                    insertCmd.Parameters.Add(new SqliteParameter("@tipo_material_id", letra.Tipo_Material_Id));
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
                    updateCmd.Parameters.AddWithValue("@tipo_material_id", letra.Tipo_Material_Id);
                    updateCmd.Parameters.AddWithValue("@quantidade", letra.Quantidade);
                    updateCmd.CommandText = Resource_Queries.MATERIAL_UPDATE;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
