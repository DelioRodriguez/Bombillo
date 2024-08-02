using System.ComponentModel.DataAnnotations;

namespace Bombillo.Data.Dto.UserDto
{
    public class UserRegisterDTO : UserBaseDto
    {
        [Required]
        [StringLength(100,ErrorMessage ="El nombre  debe tener menos de 100 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="El correo electronico debe de tener menos de 100 caracteres")]
        public string Email { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="El numero telefonico debe tener menos de 10 caracteres")]
        public string Phone { get; set; }
        [Required]
        [StringLength(11,ErrorMessage ="La cedula debe de tener menos de 11 caracteres")]
        public string Cedula { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="La direccion debe de tener menos de 100 caracteres")]
        public string Direccion { get; set; }
    }
}
