using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesionesPago.LogicaNegocios
{
    public class LogicaNegocios
    {
        AccesoDatos.AccesoDatos datos;

        public LogicaNegocios()
        {
            datos = new AccesoDatos.AccesoDatos();
        }

        public List<Entidades.qcomcve1_Result> consTipCesion(string tipo)
        {
            return datos.consTipCesion(tipo);
        }
    }
}
