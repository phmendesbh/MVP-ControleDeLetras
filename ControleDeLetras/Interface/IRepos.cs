using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeLetras.Interface
{
    public interface IRepos
    {
        /// <summary>
        /// Se não existir o banco, cria ele e a tabela
        /// </summary>
        void VerificaBanco();

        SqliteConnectionStringBuilder CriaConexao();
    }
}
