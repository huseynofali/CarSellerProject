using CarSellerProject.Models;
using CarSellerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CarSellerProject.ViewModels;
using CarSellerProject.Models;
using CarSellerProject;

namespace CarGallerySellerProject.Commands.CarGalleryGalleryCommands
{
    public class OpenDeleteCarGalleryCommand : ICommand
    {
        private readonly CarGalleriesViewModel _viewModel;

        public OpenDeleteCarGalleryCommand(CarGalleriesViewModel viewModel)
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
            int index = _viewModel.SelectedCarGalleryIndex;

            CarGalleryModel model = _viewModel.CarGalleryModels[index];

            /*ATTENTION*/
            MessageBoxResult result = MessageBox.Show($"Are you sure to delete '{model.Name} '?", "Delete CarGallery", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            ApplicationContext.DB.CarGalleryRepository.Delete(model.Id);
            _viewModel.CarGalleryModels.Remove(model);
        }
    }
}
