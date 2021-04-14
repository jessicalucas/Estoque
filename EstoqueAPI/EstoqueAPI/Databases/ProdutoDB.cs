using System;
using Dapper;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EstoqueAPI.Databases
{
    public class ProdutoDB
    {
        private static IDbConnection _dbConnection;

        public static void CreateDb(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
            var dbFilePath = configuration.GetValue<string>("DBInfo:ConnectionString");
            if (!File.Exists(dbFilePath))
            {
                _dbConnection = new SqliteConnection(connectionString);
                _dbConnection.Open();

                _dbConnection.Execute(@"
                    CREATE TABLE IF NOT EXISTS [Produto] (
                        [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        [Nome] NVARCHAR(128) NOT NULL,
                        [Quantidade] INTEGER NULL,
                        [ValorUnitario] NUMERIC NOT NULL
                    )");          
            }
        }
    }
}