using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Dao
{
    public class ShoesConfiguration : DbConfiguration
    {
        public ShoesConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}
