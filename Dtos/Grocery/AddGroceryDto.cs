using System;

namespace NetCoreAPI5.Dtos.Grocery
{
    public class AddGroceryDto
    {               
        public string Name { get; set; } = "Onions";
        
        public DateTime SprintDate { get; set; } = DateTime.Parse("04/15/2021");
    }
}