using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI5.Models;

namespace NetCoreAPI5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryController : ControllerBase
    {
        private static GrocerySet grocery = new GrocerySet();
        private static List<GrocerySet> groceryList = new List<GrocerySet>(){
            new GrocerySet(),
            new GrocerySet {Id = 1, Name = "Garlic", SprintDate = DateTime.Today}
        };

        [HttpGet("{id}")]       
        public ActionResult<GrocerySet> Get(int id)
        {
            return Ok(groceryList.FirstOrDefault(c => c.Id == id));
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult <List<GrocerySet>> GetAll()
        {
            return Ok(groceryList);
        }

        [HttpPost]
        public ActionResult<List<GrocerySet>> AddGrocery(GrocerySet grocerySet)
        {
            groceryList.Add(grocerySet);
            return Ok(groceryList);
        }

    }
}