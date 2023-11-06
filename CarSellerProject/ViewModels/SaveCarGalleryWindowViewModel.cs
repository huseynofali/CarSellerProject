using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CarSellerProject.Models;
using CarSellerProject.Commands.CarGalleryCommands;
using CarGallerySellerProject.Commands.CarGalleryGalleryCommands;

namespace CarSellerProject.ViewModels
{
    public class SaveCarGalleryWindowViewModel:BaseWindowViewModel
    {
        public SaveCarGalleryWindowViewModel(Window window, CarGalleriesViewModel parent) : base(window)
        {
            this.CarGalleryModel = new CarGalleryModel();
            this.Parent = parent;
            this.SaveCarGallery = new SaveCarGalleryCommand(this);
        }

        public CarGalleryModel CarGalleryModel { get; set; }
        public ICommand SaveCarGallery { get; set; }
        public CarGalleriesViewModel Parent { get; set; }
    }
}
