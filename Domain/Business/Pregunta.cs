using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pregunta
    {

        public int Id { get; set; }
        public string Texto { get; set; }
        public int IdTipoPregunta { get; set; }
        public int? Orden { get; set; }
        public string Instrucciones { get; set; }
        public int? IdCuestionario { get; set; }
        public decimal? Peso { get; set; }
        public decimal? RangoMaximo { get; set; }
        public decimal? RangoMinimo { get; set; }
    }
}
