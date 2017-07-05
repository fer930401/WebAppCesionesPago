using CesionesPago.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesionesPago.AccesoDatos
{
    public class AccesoDatos
    {
        skytexEntities contexto;

        public AccesoDatos()
        {
            //inicializacion de la variable contexto
            contexto = new skytexEntities();
        }

        public List<qcomcve1_Result> consTipCesion(string tipo)
        {
            List<Entidades.qcomcve1_Result> consTipCesion = contexto.qcomcve1(tipo).ToList();
            SqlConnection.ClearAllPools();
            return consTipCesion;
        }
    }
}
