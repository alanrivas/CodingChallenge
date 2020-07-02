using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public static class FormasFactory
    {
        public static FormaGeometrica getForma(FormaGeometricaEnum tipo, decimal ancho)
        {
            switch (tipo)
            {
                case FormaGeometricaEnum.Cuadrado:
                    return  new Cuadrado(tipo, ancho);
                case FormaGeometricaEnum.Circulo:
                    return new Circulo(tipo, ancho);
                case FormaGeometricaEnum.TrianguloEquilatero:
                    return new TrianguloEquilatero(tipo, ancho);
            }
            return new FormaGeometrica(tipo, ancho);

        }
    }
}
