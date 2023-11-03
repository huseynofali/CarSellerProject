using CarSellerProject.Core.DataAccessLayer.SqlServer;
using CarSellerProject.Core.DataAccessLayer;
using CarSellerProject.Core.Domain.Repositories;
using CarSellerProject.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Get(AppSettings appSettings)
        {
            switch (appSettings.DbType)
            {
                case Core.Domain.Enums.DbType.SqlServer:
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.InitialCatalog = appSettings.DbName;
                    builder.DataSource = appSettings.DbHost;
                    builder.IntegratedSecurity = appSettings.WindowsAuthentication;
                    builder.TrustServerCertificate = true;

                    if (appSettings.WindowsAuthentication == false)
                    {
                        builder.UserID = appSettings.Username;
                        builder.Password = appSettings.Password;
                    }

                    string connectionString = builder.ToString();

                    return new SqlUnitOfWork(connectionString);
                case Core.Domain.Enums.DbType.MySql:
                    return new EmptyUnitOfWork();
                case Core.Domain.Enums.DbType.InMemory:
                    return new EmptyUnitOfWork();
                default:
                    throw new NotSupportedException($"{appSettings.DbType} not supported");
            }
        }
    }
}
