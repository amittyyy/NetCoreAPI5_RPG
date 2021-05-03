using System;
namespace NetCoreAPI5.Models
{
    public class GrocerySet
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = "Onions";
        
        public DateTime SprintDate { get; set; } = DateTime.Parse("04/15/2021");
        
        
    }
}