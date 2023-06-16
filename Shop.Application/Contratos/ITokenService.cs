using Shop.Application.Dtos;
using System.Threading.Tasks;

namespace Shop.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}
