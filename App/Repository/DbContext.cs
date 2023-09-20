using System.Data;
using Microsoft.Data.SqlClient;

namespace App.Repository;

public class DbContext
{
	public IDbConnection CreateConnect(string connectStr) => new SqlConnection(connectStr);
}