using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CarSellerProject.ViewModels
{
    public class SaveCarGalleryWindowViewModel:BaseWindowViewModel
    {
        public SaveAuthorWindowViewModel(Window window, AuthorsViewModel parent) : base(window)
        {
            this.AuthorModel = new AuthorModel();
            this.Parent = parent;
            this.SaveAuthor = new SaveAuthorCommand(this);
        }

        public AuthorModel AuthorModel { get; set; }
        public ICommand SaveAuthor { get; set; }
        public AuthorsViewModel Parent { get; set; }
    }
}
