﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CarSellerProject.Models;
using programming009.LibraryManagement.Commands.LoginCommands;

namespace CarSellerProject.ViewModels
{
    public class LoginWindowViewModel : BaseWindowViewModel
    {
        public LoginWindowViewModel(Window window) : base(window)
        {
            LoginModel = new LoginModel();
            Login = new LoginCommand(this);
            OpenRegister = new OpenRegisterCommand(this);
        }

        public ICommand Login { get; set; }
        public ICommand OpenRegister { get; set; }


        private LoginModel loginModel;
        public LoginModel LoginModel
        {
            get { return loginModel; }
            set
            {
                loginModel = value;
                this.NotifyChange(nameof(LoginModel));
            }
        }


        private Visibility errorVisibility = Visibility.Hidden;
        public Visibility ErrorVisibility
        {
            get { return errorVisibility; }
            set
            {
                errorVisibility = value;
                this.NotifyChange(nameof(ErrorVisibility));
            }
        }
    }
}
