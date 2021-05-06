using AutoMapper;
using NetCoreAPI5.Dtos.Grocery;
using NetCoreAPI5.Models;

namespace NetCoreAPI5.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GrocerySet,GetGroceryDto>();
            CreateMap<AddGroceryDto,GrocerySet>();
        }
    }
}