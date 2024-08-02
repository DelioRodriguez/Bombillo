using Bombillo.BL.Interfaces;
using Bombillo.Data.Context;
using Bombillo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bombillo.BL.Services
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Users?> AuthenticateAsync(string usuario, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Usuario == usuario);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Contrasena))
                return null;

            return user;
        }

        public async Task<bool> CedulaExistsAsync(string cedula)
        {
            return await _context.Users.AnyAsync(u => u.Cedula == cedula);
        }

        public async Task RegisterAsync(Users user, string password)
        {
            user.Contrasena = BCrypt.Net.BCrypt.HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Usuario == username);
        }
    }
}
