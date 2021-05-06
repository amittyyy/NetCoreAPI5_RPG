using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAPI5.Dtos.Grocery;
using NetCoreAPI5.Models;

namespace NetCoreAPI5.Services.GroceryService
{
    public interface IGroceryService
    {
         Task<ServiceResponse<List<GetGroceryDto>>> GetAll();
         Task<ServiceResponse<GetGroceryDto>> GetGroceryById(int id);
         Task<ServiceResponse<List<GetGroceryDto>>> AddGrocery(AddGroceryDto grocerySet);
         Task<ServiceResponse<GetGroceryDto>> UpdateGrocery(UpdateGroceryDto updateGroceryDto);
         Task<ServiceResponse<List<GetGroceryDto>>> DeleteGrocery(int id);
    }
}