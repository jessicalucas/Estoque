using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace EstoqueAPI.Repositories
{
    public abstract class AbstractRepository<T>
    {
        private string _connectionString;
        protected string ConnectionString => _connectionString;
        public AbstractRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

            Databases.ProdutoDB.CreateDb(configuration);
        }
        public abstract Task Cadastrar(T item);
        public abstract Task Excluir(string nome);
        public abstract Task ExcluirPorId(int id);
        public abstract Task Atualizar(T item);
        public abstract Task<T> BuscarPorNome(string nome);
        public abstract Task<T> BuscarPorId(int id);
        public abstract Task<IEnumerable<T>> BuscarTodos();
    }
}