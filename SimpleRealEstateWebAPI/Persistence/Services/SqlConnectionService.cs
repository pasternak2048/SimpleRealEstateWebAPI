using Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Persistence.Services
{
    internal sealed class SqlConnectionService : ISqlConnectionService
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
