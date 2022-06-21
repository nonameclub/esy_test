using System.Data.Entity;
using ESY.TEST.Entity.Migrations.History;

namespace ESY.TEST.Entity
{
	public class MySqlConfiguration : DbConfiguration
	{
		public MySqlConfiguration()
		{
			SetHistoryContext("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
		}
	}
}