using AutoMapper;
using FoodkartApi.DataModels;
using FoodkartApi.DataModels.Customer;
using FoodkartApi.Model;

namespace FoodkartApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CustomerCreateDto, Customer>().ReverseMap();
            CreateMap<MenuCreateDto, Menu>().ReverseMap();
            CreateMap<OrderCreateDto, Order>().ReverseMap();
            CreateMap<OrderDetailCreateDto, OrderDetail>().ReverseMap();
            CreateMap<PaymentCreateDto, Payment>().ReverseMap();
            CreateMap<AdminCreateDto, Admin>().ReverseMap();
        }
    }
}
