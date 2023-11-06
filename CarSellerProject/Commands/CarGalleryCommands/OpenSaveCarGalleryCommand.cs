using CarSellerProject.ViewModels;
using CarSellerProject.Views;
using CarSellerProject.ViewModels;
using CarSellerProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarGallerySellerProject.Commands.CarGalleryGalleryCommands
{
    public class OpenSaveCarGalleryCommand : ICommand
    {
        private readonly CarGalleriesViewModel _viewModel;

        private bool _isUpdate;

        public OpenSaveCarGalleryCommand(CarGalleriesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveCarGalleryCommand SetAsUpdate()
        {
            _isUpdate = true;

            return this;
        }

        public void Execute(object? parameter)
        {
            SaveCarGalleryWindow window = new SaveCarGalleryWindow();
            SaveCarGalleryWindowViewModel viewModel = new SaveCarGalleryWindowViewModel(window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedCarGalleryIndex;

                viewModel.CarGalleryModel = _viewModel.CarGalleryModels[selectedIndex];
            }

            window.Show();
        }
    }
}
