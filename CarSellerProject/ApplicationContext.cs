using CarSellerProject.Core.Domain.Entities;
using CarSellerProject.Core.Domain.Enums;
using CarSellerProject.Core.Domain.Repositories;
using CarSellerProject.Factories;
using CarSellerProject.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject
{
    public static class ApplicationContext
    {
        private static AppSettings _defaultSettings = new AppSettings
        {
            DbHost = "localhost",
            DbName = "default",
            DbPort = 1433,
            DbType = DbType.SqlServer,
            Username = "",
            Password = "",
            WindowsAuthentication = true
        };

        public static string ConfigurationPath
        {
            get
            {
                string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                settingsPath = Path.Combine(settingsPath, "CarSellerProject");

                if (Directory.Exists(settingsPath) == false)
                {
                    Directory.CreateDirectory(settingsPath);
                }

                return settingsPath;
            }
        }


        public static AppSettings Settings { get; private set; }
        public static IUnitOfWork DB { get; private set; }
        public static User CurrentUser { get; set; }

        public static void Initialize()
        {
            Settings = InitializeSettings();


            DB = DbFactory.Get(Settings);
        }

        private static AppSettings InitializeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingsPath = Path.Combine(settingsPath, "CarSellerProject");

            AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            AppSettings appSettings = helper.GetSettings();

            if (appSettings is null)
            {
                appSettings = _defaultSettings;
            }

            return appSettings;
        }
    }
}
