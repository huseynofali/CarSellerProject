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
            IExporter<BookModel> exporter = new CsvExporter<BookModel>();

            OpenAddBook = new OpenSaveBookCommand(this);
            OpenUpdateBook = new OpenSaveBookCommand(this).SetAsUpdate();
            OpenDeleteBook = new OpenDeleteBookCommand(this);
            ExportBooks = new ExportBooksCommand(this, exporter);
        }

        public ObservableCollection<BookModel> BookModels { get; set; }
        public ICommand OpenAddBook { get; set; }
        public ICommand OpenUpdateBook { get; set; }
        public ICommand OpenDeleteBook { get; set; }
        public ICommand ExportBooks { get; set; }
        public int SelectedBookIndex { get; set; }

        public void Load()
        {
            BookModels = new ObservableCollection<BookModel>();

            List<Book> books = ApplicationContext.DB.BookRepository.Get();

            foreach (Book book in books)
            {
                BookModel model = new BookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Genre = book.Genre,
                    Price = book.Price,
                };

                BookModels.Add(model);
            }
        }
    }
}