using CarGallerySellerProject.Commands.CarGalleryGalleryCommands;
using CarSellerProject.Commands.CarGalleryCommands;
using CarSellerProject.Core.Domain.Entities;
using CarSellerProject.Misc;
using CarSellerProject.Misc.Abstract;
using CarSellerProject.Models;
using CarSellerProject.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSellerProject.ViewModels
{
    public class CarGalleriesViewModel:IDataLoader
    {
        public CarGalleriesViewModel()
        {
            IExporter<CarGalleryModel> exporter = new CsvExporter<CarGalleryModel>();

            OpenAddCarGallery = new OpenSaveCarGalleryCommand(this);
            OpenUpdateCarGallery = new OpenSaveCarGalleryCommand(this).SetAsUpdate();
            OpenDeleteCarGallery = new OpenDeleteCarGalleryCommand(this);
            ExportCarGalleries = new ExportCarGalleriesCommand(this, exporter);
        }

        public ObservableCollection<CarGalleryModel> CarGalleryModels { get; set; }
        public ICommand OpenAddCarGallery { get; set; }
        public ICommand OpenUpdateCarGallery { get; set; }
        public ICommand OpenDeleteCarGallery { get; set; }
        public ICommand ExportCarGalleries { get; set; }
        public int SelectedCarGalleryIndex { get; set; }

        public void Load()
        {
            CarGalleryModels = new ObservableCollection<CarGalleryModel>();

            List<CarGallery> carGallerys = ApplicationContext.DB.CarGalleryRepository.Get();

            foreach (CarGallery carGallery in carGallerys)
            {
                CarGalleryModel model = new CarGalleryModel()
                {
                    Id = carGallery.Id,
                    Name = carGallery.Name,
                    Location = carGallery.Location,
                    ContactEmail = carGallery.ContactEmail,
                    ContactPhone = carGallery.ContactPhone
                };

                CarGalleryModels.Add(model);
            }
    }
    }
}