using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public static class Idiomas
    {
        public static string traducirLinea(Resultado resultado)
        {
            if (resultado.Cantidad > 0)
            {
                if (resultado.Idioma == IdiomaEnum.Castellano)
                    return $"{resultado.Cantidad} {Idiomas.formaPorIdioma(resultado)} | Area {resultado.AreaTotal:#.##} | Perimetro {resultado.PerimetroTotal:#.##} <br/>";

                return $"{resultado.Cantidad} {Idiomas.formaPorIdioma(resultado)} | Area {resultado.AreaTotal:#.##} | Perimeter {resultado.PerimetroTotal:#.##} <br/>";
            }

            return string.Empty;
        }

        public static string formaPorIdioma(Resultado resultado)
        {
            switch (resultado.Idioma)
            {
                case IdiomaEnum.Castellano:
                    return Castellano(resultado);
                default:
                    return Ingles(resultado);
            }
        }

        private static string Ingles(Resultado resultado)
        {
            if (resultado.Cantidad == 1)
            {
                switch (resultado.TipoFigura)
                {
                    case FormaGeometricaEnum.Cuadrado:
                        return "Square";
                    case FormaGeometricaEnum.Circulo:
                        return "Circle";
                    case FormaGeometricaEnum.TrianguloEquilatero:
                        return "Triangle";
                    default:
                        return string.Empty;
                }
            }
            else
            {
                switch (resultado.TipoFigura)
                {
                    case FormaGeometricaEnum.Cuadrado:
                        return "Squares";
                    case FormaGeometricaEnum.Circulo:
                        return "Circles";
                    case FormaGeometricaEnum.TrianguloEquilatero:
                        return "Triangles";
                    default:
                        return string.Empty;
                }
            }
        }

        public static string Castellano(Resultado resultado)
        {
            if (resultado.Cantidad == 1)
            {
                switch (resultado.TipoFigura)
                {
                    case FormaGeometricaEnum.Cuadrado:
                        return "Cuadrado";
                    case FormaGeometricaEnum.Circulo:
                        return "Círculo";
                    case FormaGeometricaEnum.TrianguloEquilatero:
                        return "Triángulo";
                    default:
                        return string.Empty;
                }
            }
            else
            {
                switch (resultado.TipoFigura)
                {
                    case FormaGeometricaEnum.Cuadrado:
                        return "Cuadrados";
                    case FormaGeometricaEnum.Circulo:
                        return "Círculos";
                    case FormaGeometricaEnum.TrianguloEquilatero:
                        return "Triángulos";
                    default:
                        return string.Empty;
                }
            }
        }

        public static string Footer(IdiomaEnum idioma)
        {
            switch (idioma)
            {
                case IdiomaEnum.Castellano:
                    return "<h1>Reporte de Formas</h1>";
                default:
                    // default es inglés
                    return "<h1>Shapes report</h1>";
            }
        }
    }
}
