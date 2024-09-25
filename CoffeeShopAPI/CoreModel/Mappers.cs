using AutoMapper;
using CoffeeShopAPI.Models.ProductResponse;

namespace CoffeeShopAPI.CoreModel
{
    public class Mappers : Profile
    {
        public Mappers() 
        {
            CreateMap<Data.Product , Models.ProductResponse.GetResponse >().ReverseMap();
            CreateMap<Data.Product, Models.ProductResponse.CreateResponse>().ReverseMap();
        }
    }
}
