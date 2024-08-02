using Bombillo.BL.Interfaces;
using Bombillo.BL.Services;
using Bombillo.Data.Dto.UserDto;
using Bombillo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bombillo.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {

            if (ModelState.IsValid)
            {
                if (await userService.UserExistsAsync(model.Usuario))
                {
                    ModelState.AddModelError(nameof(model.Usuario), "El nombre de usuario ya se encuentra registrado");
                }

                if (await userService.CedulaExistsAsync(model.Cedula))
                {
                    ModelState.AddModelError(nameof(model.Cedula), " La ceula introducida ya esta registrada por otro usuario");
                }


                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = new Users
                {
                    Usuario = model.Usuario,
                    Nombre = model.Nombre,
                    Direccion = model.Direccion,
                    Cedula = model.Cedula,
                    Email = model.Email,
                    Phone = model.Phone,
                };

                await userService.RegisterAsync(user, model.Contrasena);
                return RedirectToAction("Login");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = await userService.AuthenticateAsync(model.Usuario, model.Contrasena);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales invalidas.");
                return View(model);
            }


            return RedirectToAction("Index", "Home");
        }

    }
}
