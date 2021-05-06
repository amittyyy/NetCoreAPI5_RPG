using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI5.Models;
using NetCoreAPI5.Services.GroceryService;
using System.Threading.Tasks;
using NetCoreAPI5.Dtos.Grocery;

namespace NetCoreAPI5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryController : ControllerBase
    {
        private readonly IGroceryService _groceryService;

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpGet("{id}")]       
        public async Task<ActionResult<ServiceResponse<GetGroceryDto>>> Get(int id)
        {
            return Ok(await _groceryService.GetGroceryById(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetGroceryDto>>>> GetAll()
        {
            return Ok(await _groceryService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetGroceryDto>>>> AddGrocery(AddGroceryDto grocerySet)
        {            
            return Ok(await _groceryService.AddGrocery(grocerySet));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetGroceryDto>>> UpdateGrocerySet(UpdateGroceryDto updatedGroceryDto)
        {
            var response = await _groceryService.UpdateGrocery(updatedGroceryDto);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            
            return Ok(response);      
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetGroceryDto>>> DeleteGrocery(int id)
        {
            var response = await _groceryService.DeleteGrocery(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}