using AutoMapper;
using Shop.Application.Dtos;
using Shop.Domain;
using Shop.Domain.Identity;

namespace Shop.Application.Helpers
{
    class ShopProfile: Profile
    {
        public ShopProfile()
        {
            CreateMap<Produto , ProdutoDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                .ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

        }
    }
}
