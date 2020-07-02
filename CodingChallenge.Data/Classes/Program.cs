/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class Program 
    {
        public static string Imprimir(List<IFormaGeometrica> formas, IdiomaEnum idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == IdiomaEnum.Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == IdiomaEnum.Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var listaFiguras = Enum.GetValues(typeof(FormaGeometricaEnum)).Cast<FormaGeometricaEnum>();

                var cantidadTotal = 0;
                var perimetroTotal = 0m;
                var areaTotal = 0m;
                foreach (var figura in listaFiguras)
                {
                    var resultado = calcularSegunTipo(formas, figura);
                    resultado.Idioma = idioma;
                    sb.Append(ObtenerLinea(resultado));
                    cantidadTotal += resultado.Cantidad;
                    perimetroTotal += resultado.PerimetroTotal;
                    areaTotal += resultado.AreaTotal;
                }               

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(cantidadTotal + " " + (idioma == IdiomaEnum.Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == IdiomaEnum.Castellano ? "Perimetro " : "Perimeter ") + (perimetroTotal).ToString("#.##") + " ");
                sb.Append("Area " + (areaTotal).ToString("#.##"));
            }

            return sb.ToString();
        }

        public static Resultado calcularSegunTipo(List<IFormaGeometrica> formas, FormaGeometricaEnum tipo)
        {
            var resultado = new Resultado();
            resultado.TipoFigura = tipo;
            formas = formas.Where(f => f.Tipo == tipo).ToList();
            resultado.Cantidad = formas.Count();
            resultado.AreaTotal = formas.Aggregate(0m, (acum, elem) => elem.CalcularArea() + acum);
            resultado.PerimetroTotal = formas.Aggregate(0m, (acum, elem) => elem.CalcularPerimetro() + acum);

            return resultado;
        }

        private static string ObtenerLinea(Resultado resultado)
        {
            if (resultado.Cantidad > 0)
            {
                if (resultado.Idioma == IdiomaEnum.Castellano)
                    return $"{resultado.Cantidad} {TraducirForma(resultado)} | Area {resultado.AreaTotal:#.##} | Perimetro {resultado.PerimetroTotal:#.##} <br/>";

                return $"{resultado.Cantidad} {TraducirForma(resultado)} | Area {resultado.AreaTotal:#.##} | Perimeter {resultado.PerimetroTotal:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(Resultado resultado)
        {
            switch (resultado.TipoFigura)
            {
                case FormaGeometricaEnum.Cuadrado:
                    if (resultado.Idioma == IdiomaEnum.Castellano) return resultado.Cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return resultado.Cantidad == 1 ? "Square" : "Squares";
                case FormaGeometricaEnum.Circulo:
                    if (resultado.Idioma == IdiomaEnum.Castellano) return resultado.Cantidad == 1 ? "Círculo" : "Círculos";
                    else return resultado.Cantidad == 1 ? "Circle" : "Circles";
                case FormaGeometricaEnum.TrianguloEquilatero:
                    if (resultado.Idioma == IdiomaEnum.Castellano) return resultado.Cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return resultado.Cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }


    }






}
