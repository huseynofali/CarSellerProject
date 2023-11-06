using CarSellerProject.Core.Domain.Entities;
using CarSellerProject.Models;
using CarSellerProject.ViewModels;
using CarSellerProject;
using CarSellerProject.Core.Domain.Entities;
using CarSellerProject.Models;
using CarSellerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarGallerySellerProject.Commands.CarGalleryGalleryCommands
{
    public class SaveCarGalleryCommand : ICommand
    {
        private readonly SaveCarGalleryWindowViewModel _viewModel;

        public SaveCarGalleryCommand(SaveCarGalleryWindowViewModel viewModel)
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
            CarGalleryModel model = _viewModel.CarGalleryModel;

            CarGallery carGallery = new CarGallery
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location,
                ContactEmail = model.ContactEmail,
                ContactPhone = model.ContactPhone
            };

            if (carGallery.Id > 0)
            {
                ApplicationContext.DB.CarGalleryRepository.Update(carGallery);
            }
            else
            {
                ApplicationContext.DB.CarGalleryRepository.Add(carGallery);
                model.Id = carGallery.Id;

                _viewModel.Parent.CarGalleryModels.Add(model);
            }

            _viewModel.Window.Close();
        }
    }
}
