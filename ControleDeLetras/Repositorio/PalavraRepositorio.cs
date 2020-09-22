﻿using ControleDeLetras.Entidade;
using ControleDeLetras.Interface;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ControleDeLetras.Repositorio
{
    public class PalavraRepositorio: IRepos
    {
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

        public SqliteConnectionStringBuilder CriaConexao()
        {
            var conexao = new SqliteConnectionStringBuilder
            {
                DataSource = "./palavrasDb.db"
            };

            return conexao;
        }

        public List<Palavra> Obter()
        {
            var lstPalavras = new List<Palavra>();

            using (var connection = new SqliteConnection(CriaConexao().ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = Resource_Queries.SELECT_PALAVRAS;

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

        internal void Remover(int id)
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

        internal void Inserir(string palavra)
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
                    updateCmd.CommandText = Resource_Queries.UPDATE_PALAVRAS;
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
