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
    public class SignUpViewModel : FreshBasePageModel
    {
        #region Properties

        private readonly IUsersService _usersService;
        private readonly UserSignUpValidator _signUpValidator;
        private readonly HubConnection _hub;
        
        private bool isBusy;
        private string email;
        private string emailError;
        private string password;
        private string passwordError;
        private string firstName;
        private string firstNameError;
        private string lastName;
        private string lastNameError;
        private string phoneNumber;
        private string phoneNumberError;
        
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            } 
        }
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
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                RaisePropertyChanged();
            }
        }
        public string FirstNameError
        {
            get => firstNameError;
            set
            {
                firstNameError = value;
                RaisePropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                RaisePropertyChanged();
            }
        }
        public string LastNameError
        {
            get => lastNameError;
            set
            {
                lastNameError = value;
                RaisePropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                RaisePropertyChanged();
            }
        }
        public string PhoneNumberError
        {
            get => phoneNumberError;
            set
            {
                phoneNumberError = value;
                RaisePropertyChanged();
            }
        }
        
        #endregion

        #region Commands
        
        public ICommand SignUpCommand => new FreshAwaitCommand(
            async (tcs) =>
            {
                IsBusy = true;

                var signUpDto = new UserPostDto()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,
                    PhoneNumber = PhoneNumber,
                    UserType = UserType.Customer
                };

                if (await Validate(signUpDto))
                {
                    var userDto = await _usersService.SignUpAsync(signUpDto);
                    
                    if (userDto != null)
                    {
                        Application.Current.Properties.TryAdd("userEmail", userDto.Email);
                        IsBusy = false;
                        await CoreMethods.PushPageModel<MainViewModel>();
                    }
                }
                
                Password = "";
                IsBusy = false;
                tcs.SetResult(true);
            }
        );

        #endregion

        public SignUpViewModel(IUsersService usersService)
        {
            _usersService = usersService;
            _signUpValidator = new UserSignUpValidator();
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

        private async Task<bool> Validate(UserPostDto dto)
        {
            EmailError = "";
            PasswordError = "";
            FirstNameError = "";
            LastNameError = "";
            PhoneNumberError = "";

            var result = await _signUpValidator.ValidateAsync(dto);

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
                        PasswordError = e.ErrorMessage;
                        break;
                    case nameof(dto.FirstName):
                        FirstNameError = e.ErrorMessage;
                        break;
                    case nameof(dto.LastName):
                        LastNameError = e.ErrorMessage;
                        break;
                    case nameof(dto.PhoneNumber):
                        PhoneNumberError = e.ErrorMessage;
                        break;
                }
            });

            return false;
        }
    }
}