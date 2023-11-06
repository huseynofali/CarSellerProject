using CarSellerProject.Misc.Abstract;
using CarSellerProject.Models;
using CarSellerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CarSellerProject.Commands.CarGalleryCommands
{
    public class ExportCarGalleriesCommand : ICommand
    {
        private readonly IExporter<CarGalleryModel> _exporter;
        private readonly CarGalleriesViewModel _carGalleriesViewModel;

        public ExportCarGalleriesCommand(CarGalleriesViewModel carGalleriesViewModel, IExporter<CarGalleryModel> exporter)
        {
            _carGalleriesViewModel = carGalleriesViewModel;
            _exporter = exporter;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _exporter.Export(_carGalleriesViewModel.CarGalleryModels);

            MessageBox.Show("CarGalleries successfully exported", "Export", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
