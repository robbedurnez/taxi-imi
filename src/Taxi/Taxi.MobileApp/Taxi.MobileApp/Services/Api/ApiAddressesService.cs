using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;
using Taxi.Domain.Constants;
using Xamarin.Essentials;

namespace Taxi.MobileApp.Services.Api
{
    public class ApiAddressesService : IAddressesService
    {
        private readonly IMapper _mapper;
        private readonly string _baseUri = $"{Connection.ApiHome}/api/addresses";

        public ApiAddressesService()
        {
            _mapper = App.CreateMapper();
        }

        public async Task<Address> GetAddress(string id)
        {
            var path = $"{_baseUri}/{id}";
            try
            {
                var dto = await WebApiClient.GetApiResult<AddressDto>(path);

                if (dto == null)
                {
                    return null;
                }

                var address = _mapper.Map<Address>(dto);

                return address;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var path = $"{_baseUri}/{address.Id}";

            try
            {
                var dto = _mapper.Map<Address, AddressDto>(address);
                var resultDto = await WebApiClient.PutCallApi<AddressDto, AddressDto>(path, dto);

                return _mapper.Map<AddressDto, Address>(resultDto);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<Address>> GetByUserId(string id)
        {
            var path = $"{_baseUri}/GetByUserId/{id}";
            try
            {
                var dtos = await WebApiClient.GetApiResult<List<AddressDto>>(path);

                if (dtos == null)
                {
                    return null;
                }

                var addresses = _mapper.ProjectTo<Address>(dtos.AsQueryable());

                return addresses.ToList();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Address> DeleteAddress(string id)
        {
            var path = $"{_baseUri}/{id}";
            try
            {
                var resultDto = await WebApiClient.DeleteCallApi<AddressDto>(path);

                return _mapper.Map<AddressDto, Address>(resultDto);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Address> Add(Address address)
        {
            var path = $"{_baseUri}";
            var addressLine = $"{address.AddressLine1} {address.City}";

            try
            {
                var locations = await Geocoding.GetLocationsAsync(addressLine);
                var location = locations.First();

                address.Latitude = location.Latitude;
                address.Longitude = location.Longitude;

                var dto = _mapper.Map<Address, AddressDto>(address);

                var resultDto = await WebApiClient.PostCallApi<AddressDto, AddressDto>(path, dto);

                return _mapper.Map<AddressDto, Address>(resultDto);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}