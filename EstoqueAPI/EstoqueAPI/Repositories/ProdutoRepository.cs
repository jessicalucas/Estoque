using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;
using EstoqueAPI.Models;
using System.Threading.Tasks;

namespace EstoqueAPI.Repositories
{
    public class ProdutoRepository : AbstractRepository<Produto>
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration) { }

        public override async Task Cadastrar(Produto item)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Produto (Nome, Quantidade, ValorUnitario)"
                                + " VALUES(@Nome, @Quantidade, @ValorUnitario)";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, item);
            }
        }
        public override async Task Excluir(string nome)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM Produto"
                            + " WHERE Nome = @Nome";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, new { Nome = nome });
            }
        }

        public override async Task ExcluirPorId(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM Produto"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, new { Id = id });
            }
        }

        public override async Task Atualizar(Produto item)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "UPDATE Produto SET Nome = @Nome,"
                            + " Quantidade = @Quantidade, ValorUnitario = @ValorUnitario"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                await dbConnection.QueryAsync(sQuery, item);
            }
        }
        public override async Task<Produto> BuscarPorNome(string nome)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Produto"
                            + " WHERE Nome Like %@Nome%";
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Produto>(sQuery, new { Nome = nome });
            }
        }
        public override async Task<Produto> BuscarPorId(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Produto"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Produto>(sQuery, new { Id = id });
            }
        }

        public override async Task<IEnumerable<Produto>> BuscarTodos()
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Produto>("SELECT * FROM Produto");
            }
        }
    }
}