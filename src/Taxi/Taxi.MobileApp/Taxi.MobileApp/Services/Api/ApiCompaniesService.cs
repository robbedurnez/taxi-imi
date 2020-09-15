using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.Api
{
    public class ApiCompaniesService : ICompaniesService
    {
        private readonly string _baseUri = $"{Connection.ApiHome}/api/companies";
        private readonly IMapper _mapper;

        public ApiCompaniesService()
        {
            _mapper = App.CreateMapper();
        }
        
        public async Task<Company> Get(string id)
        {
            var path = $"{_baseUri}/{id}";
            
            try
            {
                var companyDto = await WebApiClient.GetApiResult<CompanyDto>(path);
                var company = _mapper.Map<Company>(companyDto);

                return company;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}