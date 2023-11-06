using CarSellerProject.Misc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CarSellerProject.Models;
using CarSellerProject.ViewModels;

namespace CarSellerProject.Commands.CarCommands
{
    public class ExportCarsCommand : ICommand
    {
        private readonly IExporter<CarModel> _exporter;
        private readonly CarsViewModel _carsViewModel;

        public ExportCarsCommand(CarsViewModel carsViewModel, IExporter<CarModel> exporter)
        {
            _carsViewModel = carsViewModel;
            _exporter = exporter;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _exporter.Export(_carsViewModel.CarModels);

            MessageBox.Show("Cars successfully exported", "Export", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
