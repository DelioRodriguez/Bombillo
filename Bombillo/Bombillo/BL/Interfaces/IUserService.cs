using Bombillo.Models;

namespace Bombillo.BL.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(Users user, string password);
        Task<Users> AuthenticateAsync(string usuario,string password);
        Task<bool> UserExistsAsync(string username);

        Task<bool> CedulaExistsAsync(string cedula);
    }
}
