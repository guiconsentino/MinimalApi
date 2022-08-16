using System.Data;
using System.Data.SqlClient;

namespace WebApplicationApi.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-F81TLAR;Initial Catalog=car;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
