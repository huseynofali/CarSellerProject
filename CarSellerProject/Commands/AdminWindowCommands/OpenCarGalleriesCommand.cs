using CarSellerProject.ViewModels;
using CarSellerProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSellerProject.Commands.AdminWindowCommands
{
    public class OpenCarGalleriesCommand:ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenCarGalleriesCommand(AdminWindowViewModel viewModel)
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
            CarGalleriesControl control = new CarGalleriesControl();

            CarGalleriesViewModel branchesViewModel = new CarGalleriesViewModel();
            branchesViewModel.Load();

            control.DataContext = branchesViewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
