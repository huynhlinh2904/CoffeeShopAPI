using AutoMapper;
using CoffeeShopAPI.Models.Response.ProductResponse;

namespace CoffeeShopAPI.CoreModel
{
    public class Mappers : Profile
    {
        public Mappers() 
        {
            CreateMap<Data.Product , GetResponse >().ReverseMap();
            CreateMap<Data.Product, CreateResponse>().ReverseMap();
        }
    }
}
