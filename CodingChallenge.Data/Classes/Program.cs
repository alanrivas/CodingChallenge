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
                sb.Append(Traductor.traducirEncabezado(idioma));

                var listaFiguras = Enum.GetValues(typeof(FormaGeometricaEnum)).Cast<FormaGeometricaEnum>();
                var resultadoTotal = new Resultado();
                resultadoTotal.Idioma = idioma;

                foreach (var figura in listaFiguras)
                {
                    var resultado = calcularSegunTipo(formas, figura);
                    resultado.Idioma = idioma;
                    sb.Append(Idiomas.traducirLinea(resultado));
                    resultadoTotal.Cantidad += resultado.Cantidad;
                    resultadoTotal.PerimetroTotal += resultado.PerimetroTotal;
                    resultadoTotal.AreaTotal += resultado.AreaTotal;
                }

                // FOOTER
                sb.Append(Traductor.traducirFooter(resultadoTotal));
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

       


    }






}
