using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesionesPago.LogicaNegocios
{
    public class variables
    {
        static int num_fol;
        public static int Num_Fol
        {
            get { return variables.num_fol; }
            set { variables.num_fol = value; }
        }

        static string tipCesionPago;
        public static string TipCesionPago
        {
            get { return variables.tipCesionPago; }
            set { variables.tipCesionPago = value; }
        }

        static string tipPago;
        public static string TipPago
        {
            get { return variables.tipPago; }
            set { variables.tipPago = value; }
        }

        static DateTime fecGenerado;
        public static DateTime FecGenerado
        {
            get { return variables.fecGenerado; }
            set { variables.fecGenerado = value; }
        }
    }
}
