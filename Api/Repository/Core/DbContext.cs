using System.Data;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Api.Repository.Core;

public class DbContext
{
	private readonly string _connectStr;

	public DbContext(string connectStr)
	{
		_connectStr = connectStr;
	}
	public IDbConnection CreateConnect() => new SqlConnection(_connectStr);
}