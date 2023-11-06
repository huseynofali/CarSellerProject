using CarSellerProject.Commands.CarCommands;
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
    public class CarsViewModel:IDataLoader
    {
        public CarsViewModel()
        {
            IExporter<CarModel> exporter = new CsvExporter<CarModel>();

            OpenAddCar = new OpenSaveCarCommand(this);
            OpenUpdateCar = new OpenSaveCarCommand(this).SetAsUpdate();
            OpenDeleteCar = new OpenDeleteCarCommand(this);
            ExportCars = new ExportCarsCommand(this, exporter);
        }

        public ObservableCollection<CarModel> CarModels { get; set; }
        public ICommand OpenAddCar { get; set; }
        public ICommand OpenUpdateCar { get; set; }
        public ICommand OpenDeleteCar { get; set; }
        public ICommand ExportCars { get; set; }
        public int SelectedCarIndex { get; set; }

        public void Load()
        {
            CarModels = new ObservableCollection<CarModel>();

            List<Car> carGallerys = ApplicationContext.DB.CarRepository.Get();

            foreach (Car carGallery in carGallerys)
            {
                CarModel model = new CarModel()
                {
                    Id = carGallery.Id,
                    Make = carGallery.Make,
                    Model = carGallery.Model,
                    Year = carGallery.Year,
                    Price = carGallery.Price,
                    Mileage = carGallery.Mileage,
                    Color = carGallery.Color,
                    GalleryID = carGallery.GalleryID
                };

                CarModels.Add(model);
            }
        }
    }
}

