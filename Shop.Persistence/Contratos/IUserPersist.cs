using Shop.Domain.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Persistence.Contratos
{
    public interface IUserPersist: IGeralPersist
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}
