using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using gear_up_api.Context;
using gear_up_api.Models;

namespace gear_up_api.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly GearUpDbContext _context;

        public UserRepository(GearUpDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            if (await _context.Users.AnyAsync(x => x.Username == user.Username))
                throw new Exception("Username \"" + user.Username + "\" is already taken");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
