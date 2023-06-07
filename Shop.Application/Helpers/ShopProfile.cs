using AutoMapper;
using Shop.Application.Dtos;
using Shop.Domain;

namespace Shop.Application.Helpers
{
    class ShopProfile: Profile
    {
        public ShopProfile()
        {
            CreateMap<Produto , ProdutoDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();

        }

    }
}
