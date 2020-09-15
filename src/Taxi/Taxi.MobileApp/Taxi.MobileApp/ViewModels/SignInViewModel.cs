using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Microsoft.AspNetCore.SignalR.Client;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Validators;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Taxi.MobileApp.ViewModels
{
    public class SignInViewModel : FreshBasePageModel
    {
        #region Properties
        
        private readonly IUsersService _usersService;
        private readonly UserSignInValidator _validator;
        private readonly HubConnection _hub;
        
        private string email;
        private string emailError;
        private string password;
        private string passwordError;
        private bool isBusy;
        
        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }
        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                RaisePropertyChanged();
            } 
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            } 
        }
        
        #endregion

        #region Commands

        public ICommand SignInCommand => new FreshAwaitCommand(
            async tcs =>
            {
                IsBusy = true;

                var loginDto = new UserLoginDto()
                {
                    Email = Email,
                    Password = Password
                };

                if (await Validate(loginDto))
                {
                    var userDto = await _usersService.SignInAsync(loginDto);

                    if (userDto != null)
                    {
                        Application.Current.Properties.TryAdd("userEmail", userDto.Email);
                        var userType = userDto.UserType;
                        if (userType == UserType.Customer)
                        {
                            IsBusy = false;
                            await CoreMethods.PushPageModel<MainViewModel>();
                        }
                        else
                        {
                            IsBusy = false;
                            await CoreMethods.PushPageModel<DriverMainViewModel>();
                        }
                    }
                }

                Password = "";
                IsBusy = false;
                tcs.SetResult(true);
            }
        );

        #endregion
        
        public SignInViewModel(IUsersService usersService)
        {
            _usersService = usersService;
            _validator = new UserSignInValidator();
            _hub = new HubConnectionBuilder()
                .WithUrl(Connection.SignalRHome)
                .WithAutomaticReconnect()
                .Build();
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            
            if (_hub.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await _hub.StartAsync();
                }
                catch (HttpRequestException)
                {
                    await CoreMethods.PushPageModel<NoConnectionViewModel>("Could not connect to server.");
                }
            }
        }

        private async Task<bool> Validate(UserLoginDto dto)
        {
            EmailError = "";
            PasswordError = "";
            
            var result = await _validator.ValidateAsync(dto);

            if (result.IsValid)
            {
                return true;
            }
            
            result.Errors.ForEach(e =>
            {
                switch (e.PropertyName)
                {
                    case nameof(dto.Email):
                        EmailError = e.ErrorMessage;
                        break;
                    case nameof(dto.Password):
                        passwordError = e.ErrorMessage;
                        break;
                }
            });

            return false;
        }
    }
}