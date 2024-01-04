
using Microsoft.Data.SqlClient;

namespace Application.Common.Interfaces
{
    public interface ISqlConnectionService
    {
        SqlConnection CreateConnection();
    }
}
