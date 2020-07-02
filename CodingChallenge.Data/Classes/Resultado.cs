using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Resultado
    {
        public int Cantidad { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal PerimetroTotal { get; set; }
        public FormaGeometricaEnum TipoFigura { get; set; }
        public IdiomaEnum Idioma { get; set; }
    }
}
