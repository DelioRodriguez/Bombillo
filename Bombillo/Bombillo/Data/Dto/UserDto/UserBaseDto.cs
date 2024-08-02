using System.ComponentModel.DataAnnotations;

namespace Bombillo.Data.Dto.UserDto
{
    public class UserBaseDto
    {
        [Required]
        [StringLength(100, ErrorMessage ="El nombre de usuario debe tener menos de 100 caracteres")]
        [MinLength(4,ErrorMessage ="El nombre de usuario debe tener mas de 4 caracteres")]
        public string Usuario { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="La password debe de ser menor a 100 caracteres")]
        [MinLength(8,ErrorMessage ="La password debe de tener mas de 8 carcteres")]
        public string Contrasena { get; set; }

    }
}
