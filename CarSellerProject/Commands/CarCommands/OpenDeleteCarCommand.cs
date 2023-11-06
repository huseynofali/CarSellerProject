using CarSellerProject.Models;
using CarSellerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarSellerProject.Commands.CarCommands
{
    public class OpenDeleteCarCommand : ICommand
    {
        private readonly CarsViewModel _viewModel;

        public OpenDeleteCarCommand(CarsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int index = _viewModel.SelectedCarIndex;

            CarModel model = _viewModel.CarModels[index];

            /*ATTENTION*/
            MessageBoxResult result = MessageBox.Show($"Are you sure to delete '{model.Make} {model.Model}'?", "Delete Car", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            ApplicationContext.DB.CarRepository.Delete(model.Id);
            _viewModel.CarModels.Remove(model);
        }
    }
}
