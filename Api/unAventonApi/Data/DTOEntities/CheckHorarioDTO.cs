using System;
using System.Collections.Generic;

namespace unAventonApi.Data.DTOEntities
{
    public class CheckHorarioDTO
    {
        public IList<DateTime> DiasDeViaje { get; set; }
        public TimeSpan HoraPartida { get; set; }
        public TimeSpan Duracion { get; set; }
    }
}