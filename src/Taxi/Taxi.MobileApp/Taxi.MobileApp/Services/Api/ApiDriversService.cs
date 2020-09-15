using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.Api
{
    public class ApiDriversService : IDriversService
    {
        private IMapper _mapper;
        private readonly string _baseUri = $"{Connection.ApiHome}/api/drivers";

        public ApiDriversService()
        {
            _mapper = App.CreateMapper();
        }

        public async Task<List<Driver>> Get()
        {
            var path = $"{_baseUri}";
            try
            {
                var driverDtos = await WebApiClient.GetApiResult<List<DriverDto>>(path);

                if (driverDtos == null)
                {
                    return null;
                }

                var drivers = _mapper.ProjectTo<Driver>(driverDtos.AsQueryable()).ToList();

                return drivers;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<Driver>> GetInRange(double latitude, double longitude, int km)
        {
            var path = $"{_baseUri}/GetInRange";
            var postDto = new DriverInRangeDto()
            {
                Latitude = latitude,
                Longitude = longitude,
                MaxDistanceInKm = km
            };

            try
            {
                var driverDtos = await WebApiClient.PostCallApi<List<DriverDto>, DriverInRangeDto>(path, postDto);

                if (driverDtos == null)
                {
                    return null;
                }

                var drivers = _mapper.ProjectTo<Driver>(driverDtos.AsQueryable()).ToList();

                return drivers;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Driver> GetById(string id)
        {
            var path = $"{_baseUri}/{id}";

            try
            {
                var dto = await WebApiClient.GetApiResult<DriverDto>(path);

                if (dto == null)
                {
                    return null;
                }

                var driver = _mapper.Map<Driver>(dto);
            
                return driver;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Driver> ToggleActive(Driver driver)
        {
            var path = $"{_baseUri}/ToggleActive";
            var dto = _mapper.Map<DriverDto>(driver);

            try
            {
                var result = await WebApiClient.PutCallApi<DriverDto, DriverDto>(path, dto);

                return result == null ? null : _mapper.Map<Driver>(result); 
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Driver> ToggleAvailable(Driver driver)
        {
            var path = $"{_baseUri}/ToggleAvailable";
            var dto = _mapper.Map<DriverDto>(driver);
            try
            {
                var result = await WebApiClient.PutCallApi<DriverDto, DriverDto>(path, dto);

                return result == null ? null : _mapper.Map<Driver>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Driver> UpdateLocation(Driver driver)
        {
            var path = $"{_baseUri}/UpdateLocation";
            var dto = _mapper.Map<DriverDto>(driver);

            try
            {
                var result = await WebApiClient.PutCallApi<DriverDto, DriverDto>(path, dto);

                return result == null ? null : _mapper.Map<Driver>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}