using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] FotoPerfil { get; set; }

        public IList<Vehiculo> Vehiculos { get; set; }

        public IList<Tarjeta> Tarjetas { get; set; }

    }
}