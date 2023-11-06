using CarSellerProject.Commands.AdminWindowCommands;
using CarSellerProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarSellerProject.ViewModels
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(AdminWindow window) : base(window)
        {
            OpenCars = new OpenCarsCommand(this);
            OpenCarGalleries = new OpenCarGalleriesCommand(this);
        }

        public ICommand OpenCars { get; set; }
        public ICommand OpenCarGalleries { get; set; }
        public Grid CenterGrid { get; set; }
    }
}
