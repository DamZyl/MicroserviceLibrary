using System.Data;

namespace MicroserviceLibrary.Application.Configurations.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}