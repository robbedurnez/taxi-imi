using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;
using Taxi.Domain.Models;

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMappingRepository<CompanyDto> _companyRepository;
        private readonly IMappingRepository<CustomerDto> _customerRepository;
        private readonly IMappingRepository<DriverDto> _driverRepository;
        private readonly IMappingRepository<AddressDto> _addressRepository;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMappingRepository<CompanyDto> companyRepository,
            IMappingRepository<CustomerDto> customerRepository,
            IMappingRepository<DriverDto> driverRepository,
            IMappingRepository<AddressDto> addressRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _driverRepository = driverRepository;
            _addressRepository = addressRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with id {id} not found");
            }

            var userDto = await ReturnUserFromRoleAsync(user);

            return Ok(userDto);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserPostDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return BadRequest($"Account with email {model.Email} already exists");
            }

            var user = new ApplicationUser()
            {
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            if (model.UserType == UserType.Company)
            {
                user.UserName = model.Name;
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest("User could not be created");
            }

            var roleName = model.UserType.ToString();
            var roleResult = await _userManager.AddToRoleAsync(user, roleName);

            if (!roleResult.Succeeded)
            {
                return BadRequest($"User could not be added to role {model.UserType.ToString()}");
            }

            UserDto dtoToReturn;

            switch (model.UserType)
            {
                case UserType.Customer:
                    var dto = new CustomerDto()
                    {
                        Id = user.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserType = model.UserType,
                        Addresses = new List<AddressDto>()
                    };

                    dtoToReturn = await _customerRepository.Add(dto);
                    break;
                case UserType.Company:
                    await _addressRepository.Add(new AddressDto()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AddressLine1 = model.Address.AddressLine1,
                        AddressLine2 = model.Address.AddressLine2,
                        PostalCode = model.Address.PostalCode,
                        City = model.Address.City,
                        UserId = user.Id
                    });

                    var companyDto = new CompanyDto()
                    {
                        Id = user.Id,
                        Name = model.Name,
                        Drivers = new List<DriverDto>(),
                        Orders = new List<OrderDto>(),
                        UserType = model.UserType
                    };

                    dtoToReturn = await _companyRepository.Add(companyDto);
                    break;
                case UserType.Driver:
                    var driverDto = new DriverDto()
                    {
                        Id = user.Id,
                        UserType = model.UserType,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CompanyId = model.CompanyId,
                        Latitude = 0,
                        Longitude = 0
                    };

                    dtoToReturn = await _driverRepository.Add(driverDto);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            dtoToReturn.Email = user.Email;
            dtoToReturn.PhoneNumber = user.PhoneNumber;

            return Ok(dtoToReturn);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound($"User with email {model.Email} not found");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (!signInResult.Succeeded)
            {
                return Unauthorized("Wrong password");
            }

            var dtoToReturn = await ReturnUserFromRoleAsync(user);

            return dtoToReturn == null
                ? (IActionResult) BadRequest($"User with id {user.Id} could not be signed in")
                : Ok(dtoToReturn);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UserPutDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!id.Equals(model.Id))
            {
                return BadRequest($"Route id {id} doesn't match ApplicationUser id {model.Id}");
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest($"User with id {id} does not exist");
            }

            if (!user.Email.Equals(model.Email))
            {
                var emailToken = await _userManager.GenerateChangeEmailTokenAsync(user, model.Email);
                var emailResult = await _userManager.ChangeEmailAsync(user, model.Email, emailToken);

                if (!emailResult.Succeeded)
                {
                    return BadRequest("Email could not be changed");
                }
            }

            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest("User could not be updated");
            }

            var dtoToReturn = await ReturnUserFromRoleAsync(user);

            return dtoToReturn == null
                ? (IActionResult) BadRequest($"User with id {user.Id} could not be updated")
                : Ok(dtoToReturn);
        }

        [HttpPost("CompanySignIn")]
        public async Task<IActionResult> CompanySignIn([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound($"User with email {model.Email} not found");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains("Company"))
            {
                return Unauthorized();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (!signInResult.Succeeded)
            {
                return Unauthorized("Wrong password");
            }

            var dtoToReturn = await _companyRepository.GetById(user.Id);

            return dtoToReturn == null
                ? (IActionResult) BadRequest($"User with id {user.Id} could not be signed in")
                : Ok(dtoToReturn);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with id {id} could not be found");
            }

            var role = (await _userManager.GetRolesAsync(user)).First();

            var dtoToReturn = role.ToUpper() switch
            {
                "CUSTOMER" => (UserDto) await _customerRepository.Delete(user.Id),
                "DRIVER" => await _driverRepository.Delete(user.Id),
                "COMPANY" => await _companyRepository.Delete(user.Id),
                _ => throw new ArgumentOutOfRangeException()
            };

            dtoToReturn.Email = user.Email;
            dtoToReturn.PhoneNumber = user.PhoneNumber;

            var addresses = await _addressRepository
                .GetFiltered(a => a.UserId == user.Id)
                .ToListAsync();

            addresses?.ForEach(a =>
            {
                _addressRepository.Delete(a.Id);
            });

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest($"User with id {id} could not be deleted");
            }

            return Ok(dtoToReturn);
        }

        private async Task<UserDto> ReturnUserFromRoleAsync(ApplicationUser user)
        {
            var role = (await _userManager.GetRolesAsync(user)).First();

            var dtoToReturn = role.ToUpper() switch
            {
                "CUSTOMER" => (UserDto) await _customerRepository.GetById(user.Id),
                "DRIVER" => await _driverRepository.GetById(user.Id),
                "COMPANY" => await _companyRepository.GetById(user.Id),
                _ => throw new ArgumentOutOfRangeException()
            };

            dtoToReturn.Email = user.Email;
            dtoToReturn.PhoneNumber = user.PhoneNumber;

            return dtoToReturn;
        }
    }
}