using Microsoft.EntityFrameworkCore;
using Shop.Domain.Identity;
using Shop.Persistence.Contexto;
using Shop.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence
{
    public class UserPersist : GeralPersist, IUserPersist
    {
        private readonly ShopContext _context;
        public UserPersist(ShopContext context):base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
