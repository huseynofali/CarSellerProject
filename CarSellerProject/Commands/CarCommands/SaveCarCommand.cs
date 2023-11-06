using CarSellerProject.Core.Domain.Entities;
using CarSellerProject.Models;
using CarSellerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSellerProject.Commands.CarCommands
{
    public class SaveCarCommand:ICommand
    {
        private readonly SaveCarWindowViewModel _viewModel;

        public SaveCarCommand(SaveCarWindowViewModel viewModel)
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
            CarModel model = _viewModel.CarModel;

            Car car = new Car
            {
                Id = model.Id,
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                Price = model.Price,
                Mileage = model.Mileage,
                Color = model.Color,
                GalleryID = model.GalleryID
            };

            if (car.Id > 0)
            {
                ApplicationContext.DB.CarRepository.Update(car);
            }
            else
            {
                ApplicationContext.DB.CarRepository.Add(car);
                model.Id = car.Id;

                _viewModel.Parent.CarModels.Add(model);
            }

            _viewModel.Window.Close();
        }
    }
}
