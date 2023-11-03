using CarSellerProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CarSellerProject.ViewModels
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window) : base(window)
        {
            AppSettings currentSettings = ApplicationContext.Settings;

            Configuration = new ConfigurationModel
            {
                WindowsAuthentication = currentSettings.WindowsAuthentication,
                DbHost = currentSettings.DbHost,
                DbName = currentSettings.DbName,
                DbPort = currentSettings.DbPort,
                DbType = currentSettings.DbType,
                Username = currentSettings.Username,
            };

            SupportedDbTypes = Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();

            Save = new SaveCommand(this);
            Cancel = new CancelCommand(this);
        }

        public ConfigurationModel Configuration { get; set; }
        public List<DatabaseType> SupportedDbTypes { get; set; }

        public ICommand Cancel { get; set; }
        public ICommand Save { get; set; }
    }
}
