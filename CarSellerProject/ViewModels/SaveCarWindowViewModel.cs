using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CarSellerProject.Commands.CarCommands;
using CarSellerProject.Models;

namespace CarSellerProject.ViewModels
{
    public class SaveCarWindowViewModel:BaseWindowViewModel
    {
        public SaveCarWindowViewModel(Window window, CarsViewModel parent) : base(window)
        {
            this.CarModel = new CarModel();
            this.Parent = parent;
            this.SaveCar = new SaveCarCommand(this);
        }

        public CarModel CarModel { get; set; }
        public ICommand SaveCar { get; set; }
        public CarsViewModel Parent { get; set; }
    }
}
