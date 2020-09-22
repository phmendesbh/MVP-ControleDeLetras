using Microsoft.Data.Sqlite;

namespace ControleDeLetras.Repositorio
{
    public class RepositorioBase
    {
        public SqliteConnectionStringBuilder CriaConexao()
        {
            var conexao = new SqliteConnectionStringBuilder
            {
                DataSource = "./DB_Adornos.db"
            };

            return conexao;
        }
    }
}