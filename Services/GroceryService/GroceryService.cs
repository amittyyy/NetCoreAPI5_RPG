using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NetCoreAPI5.Dtos.Grocery;
using NetCoreAPI5.Models;

namespace NetCoreAPI5.Services.GroceryService
{
    public class GroceryService : IGroceryService
    {
        private static List<GrocerySet> groceryList = new List<GrocerySet>(){
            new GrocerySet(),
            new GrocerySet {Id=1,Name="Pineapple", SprintDate = DateTime.Today }
        };

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GroceryService(IMapper mapper, ILogger<GroceryService> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<GetGroceryDto>>> AddGrocery(AddGroceryDto grocerySet)
        {
            var serviceResponse = new ServiceResponse<List<GetGroceryDto>>();
            GrocerySet grocery = _mapper.Map<GrocerySet>(grocerySet);
            grocery.Id = groceryList.Max(c => c.Id) + 1;
            groceryList.Add(grocery);
            serviceResponse.Data = groceryList.Select(c => _mapper.Map<GetGroceryDto>(c)).ToList();;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGroceryDto>>> DeleteGrocery(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGroceryDto>>();
            try
            {
                GrocerySet grocery = groceryList.First(c => c.Id == id);
                groceryList.Remove(grocery);
                serviceResponse.Data = groceryList.Select(c => _mapper.Map<GetGroceryDto>(c)).ToList();

            }
             catch(Exception ex)
             {
                 serviceResponse.Success = false;
                 serviceResponse.Message = ex.Message;
                 _logger.LogError($"Log on Delete Grocery: {ex.Message}");
             }

             return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGroceryDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetGroceryDto>>();
            serviceResponse.Data = groceryList.Select(c => _mapper.Map<GetGroceryDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGroceryDto>> GetGroceryById(int id)
        {
            var serviceResponse = new ServiceResponse<GetGroceryDto>();
            serviceResponse.Data = _mapper.Map<GetGroceryDto>(groceryList.FirstOrDefault(c => c.Id == id ));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGroceryDto>> UpdateGrocery(UpdateGroceryDto updateGroceryDto)
        {
            // _logger.LogInformation("amity is here");
           var serviceResponse = new ServiceResponse<GetGroceryDto>();
           try
           {
                GrocerySet grocerySet = groceryList.FirstOrDefault(c => c.Id == updateGroceryDto.Id);

                grocerySet.Name = updateGroceryDto.Name;
                grocerySet.SprintDate = updateGroceryDto.SprintDate;

                serviceResponse.Data = _mapper.Map<GetGroceryDto>(grocerySet);
           }
           catch(Exception ex)
           {
               serviceResponse.Success = false;
               serviceResponse.Message = ex.Message;
               _logger.LogError($"Log on Update Grocery: {ex.Message}");

           }

           return serviceResponse;

        }
    }
}