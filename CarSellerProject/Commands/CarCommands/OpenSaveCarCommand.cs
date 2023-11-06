using CarSellerProject.ViewModels;
using CarSellerProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSellerProject.Commands.CarCommands
{
    public class OpenSaveCarCommand :ICommand
    {
        private readonly CarsViewModel _viewModel;

        private bool _isUpdate;

        public OpenSaveCarCommand(CarsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveCarCommand SetAsUpdate()
        {
            _isUpdate = true;

            return this;
        }

        public void Execute(object? parameter)
        {
            SaveCarWindow window = new SaveCarWindow();
            SaveCarWindowViewModel viewModel = new SaveCarWindowViewModel(window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedCarIndex;

                viewModel.CarModel = _viewModel.CarModels[selectedIndex];
            }

            window.Show();
        }
    }
}
