using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica : IFormaGeometrica
    {
        public FormaGeometrica(FormaGeometricaEnum tipo, decimal ancho)
        {
            Tipo = tipo;
            Lado = ancho;
        }

        public FormaGeometrica()
        {
        }

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public FormaGeometricaEnum Tipo { get; set; }
        public decimal Lado { get; set; }
    }
}
