using AutoMapper;
using On.Application.Commands.Customers;
using On.Domain.Entites;

namespace On.Application.Mappers
{
    public class CustomerMapper: Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, AddCustomerCommand>()
                .ForMember(cfg => cfg.State, act => act.MapFrom(src => src.Address.State))
                .ForMember(cfg => cfg.Country, act => act.MapFrom(src => src.Address.Country))
                .ForMember(cfg => cfg.Street, act => act.MapFrom(src => src.Address.Street))
                .ForMember(cfg => cfg.ZipCode, act => act.MapFrom(src => src.Address.Zipcode))
                .ForMember(cfg => cfg.City, act => act.MapFrom(src => src.Address.City));

            CreateMap<Customer, UpdateCustomerCommand>()
             .ForMember(cfg => cfg.State, act => act.MapFrom(src => src.Address.State))
             .ForMember(cfg => cfg.Country, act => act.MapFrom(src => src.Address.Country))
             .ForMember(cfg => cfg.Street, act => act.MapFrom(src => src.Address.Street))
             .ForMember(cfg => cfg.ZipCode, act => act.MapFrom(src => src.Address.Zipcode))
             .ForMember(cfg => cfg.City, act => act.MapFrom(src => src.Address.City));

            CreateMap<AddCustomerCommand, Customer>()
                .ForMember(cfg => cfg.Address, act => act.MapFrom(src => new CustomerAddress(src.Street,src.City,src.State,src.Country,src.ZipCode)));

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(cfg => cfg.Address, act => act.MapFrom(src => new CustomerAddress(src.Street, src.City, src.State, src.Country, src.ZipCode)));
        }
    }
}
