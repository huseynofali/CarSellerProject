﻿using CarSellerProject;
using CarSellerProject.Models;
using CarSellerProject.Settings;
using CarSellerProject.ViewModels;
using CarSellerProject.Views;

using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarSellerProject.Commands.ConfigurationCommands
{
    public class SaveCommand : ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public SaveCommand(ConfigurationViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }   

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AppSettingsHelper helper = new AppSettingsHelper(ApplicationContext.ConfigurationPath);
            ConfigurationModel config = _viewModel.Configuration;
            PasswordBox passwordBox = (PasswordBox)parameter;

            AppSettings appSettings = new AppSettings
            {
                WindowsAuthentication = config.WindowsAuthentication,
                DbHost = config.DbHost,
                DbName= config.DbName,
                DbPort = config.DbPort,
                DbType = config.DbType,
            };


            if(config.WindowsAuthentication == false)
            {
                appSettings.Username = config.Username;
                appSettings.Password = passwordBox.Password;
            }

            helper.SaveSettings(appSettings);

            WindowStart startWindow = new WindowStart();
            startWindow.Show();
            _viewModel.Window.Close();
        }
    }
}
