using System;

namespace unAventonApi.Data.DTOEntities
{
    public class UserDTO
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}