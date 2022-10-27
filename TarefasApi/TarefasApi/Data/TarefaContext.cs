using Dapper.Contrib.Extensions;
using System.Data;

namespace TarefasApi.Data;

public class TarefaContext
{
    public delegate Task<IDbConnection> GetConnection();
}