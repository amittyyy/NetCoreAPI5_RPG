using System;

namespace NetCoreAPI5.Dtos.Grocery
{
    public class GetGroceryDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = "Onions";
        
        public DateTime SprintDate { get; set; } = DateTime.Parse("04/15/2021");
    }
}