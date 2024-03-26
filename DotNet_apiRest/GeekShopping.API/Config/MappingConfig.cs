using AutoMapper;
using GeekShopping.API.Model;
using GeekShopping.API.Model.Data.Dto;

namespace GeekShopping.API.Config;

public class MappingConfig {
    public static MapperConfiguration RegisterMaps() {
        return new MapperConfiguration(config => {
            config.CreateMap<ProductDTO, Product>();
            config.CreateMap<Product, ProductDTO>();
        });
    }
}