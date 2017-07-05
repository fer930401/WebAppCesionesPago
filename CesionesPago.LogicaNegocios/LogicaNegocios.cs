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

        public int ultFolio(string ef_cve, string tipdoc_cve)
        {
            return datos.ultFolio(ef_cve, tipdoc_cve);
        }

        public List<Entidades.sp_lisdetctmov7_Result> consCtmov(string ef_cve, string tipdoc_cve, string tipdoc_cvep, int? num_fol)
        {
            return datos.consCtmov(ef_cve, tipdoc_cve, tipdoc_cvep, num_fol);
        }

        public Entidades.sp_WebAppInsertaCtmov_Result insertCtmov(int? num_fol, DateTime fec_mov, int? plazo_pp, string refer, string ef_cve, string tipdoc_cve)
        {
            return datos.insertCtmov(num_fol, fec_mov, plazo_pp, refer, ef_cve, tipdoc_cve);
        }
    }
}
