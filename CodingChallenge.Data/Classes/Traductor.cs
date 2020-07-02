using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public static class Traductor
    {
        public static string traducirEncabezado(IdiomaEnum idioma)
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

        public static string traducirFooter(Resultado resultado)
        {
            var respuesta = string.Empty;
            respuesta += "TOTAL:<br/>";
            respuesta += resultado.Cantidad + " " + (resultado.Idioma == IdiomaEnum.Castellano ? "formas" : "shapes") + " ";
            respuesta += (resultado.Idioma == IdiomaEnum.Castellano ? "Perimetro " : "Perimeter ") + (resultado.PerimetroTotal).ToString("#.##") + " ";
            respuesta += "Area " + (resultado.AreaTotal).ToString("#.##");

            return respuesta;
        }

        
    }
}
