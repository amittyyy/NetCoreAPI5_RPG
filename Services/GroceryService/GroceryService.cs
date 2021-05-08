using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreAPI5.Data;
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
        private readonly DataContext _context;
        public GroceryService(IMapper mapper, ILogger<GroceryService> logger, DataContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetGroceryDto>>> AddGrocery(AddGroceryDto grocerySet)
        {
            var serviceResponse = new ServiceResponse<List<GetGroceryDto>>();
            GrocerySet grocery = _mapper.Map<GrocerySet>(grocerySet); 
            await _context.GrocerySets.AddAsync(grocery);           
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.GrocerySets.Select(c => _mapper.Map<GetGroceryDto>(c)).ToListAsync();;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGroceryDto>>> DeleteGrocery(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGroceryDto>>();
            try
            {
                GrocerySet grocery = await _context.GrocerySets.FirstAsync(c => c.Id == id);                
                _context.GrocerySets.Remove(grocery);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.GrocerySets.Select(c => _mapper.Map<GetGroceryDto>(c)).ToListAsync();

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
            var dbGercerySet = await _context.GrocerySets.ToListAsync();
            serviceResponse.Data = dbGercerySet.Select(c => _mapper.Map<GetGroceryDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGroceryDto>> GetGroceryById(int id)
        {
            var serviceResponse = new ServiceResponse<GetGroceryDto>();
            var dbGrocery = await _context.GrocerySets.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetGroceryDto>(dbGrocery);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGroceryDto>> UpdateGrocery(UpdateGroceryDto updateGroceryDto)
        {
            // _logger.LogInformation("amity is here");
           var serviceResponse = new ServiceResponse<GetGroceryDto>();
           try
           {
                GrocerySet grocerySet = await _context.GrocerySets.FirstOrDefaultAsync(c => c.Id == updateGroceryDto.Id);

                grocerySet.Name = updateGroceryDto.Name;
                grocerySet.SprintDate = updateGroceryDto.SprintDate;

                await _context.SaveChangesAsync();
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