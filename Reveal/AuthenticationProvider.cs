
using Reveal.Sdk;
using Reveal.Sdk.Data;
using Reveal.Sdk.Data.Microsoft.SqlServer;

namespace RevealSdk.Server.Reveal
{
    public class AuthenticationProvider : IRVAuthenticationProvider
    {
        public Task<IRVDataSourceCredential> ResolveCredentialsAsync(IRVUserContext userContext,
            RVDashboardDataSource dataSource)
        {        
            IRVDataSourceCredential userCredential = new RVUsernamePasswordDataSourceCredential();

            string username = Environment.GetEnvironmentVariable("DB_USER_NAME");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (dataSource is RVSqlServerDataSource)
            {
                userCredential = new RVUsernamePasswordDataSourceCredential(username, password);
            }
            return Task.FromResult(userCredential);
        }
    }
}

