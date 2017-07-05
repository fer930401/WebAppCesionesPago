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

        public int ultFolio(string ef_cve, string tipdoc_cve)
        {
            int num_fol;
            var consultaFolio = (from xu in contexto.xufolios
                                 where xu.ef_cve.Equals(ef_cve)
                                         && xu.tipdoc_cve.Equals(tipdoc_cve)
                                 select xu).SingleOrDefault();
            if (consultaFolio == null)
            {
                num_fol = 0;
            }
            else
            {
                num_fol = consultaFolio.ult_fol;
            }
            return num_fol + 1;
        }

        public List<sp_lisdetctmov7_Result> consCtmov(string ef_cve, string tipdoc_cve, string tipdoc_cvep, int? num_fol)
        {
            List<Entidades.sp_lisdetctmov7_Result> consCtmov = contexto.sp_lisdetctmov7(ef_cve,tipdoc_cve,tipdoc_cvep,num_fol).ToList();
            SqlConnection.ClearAllPools();
            return consCtmov;
        }

        public sp_WebAppInsertaCtmov_Result insertCtmov(int? num_fol, DateTime fec_mov, int? plazo_pp, string refer, string ef_cve, string tipdoc_cve)
        {
            return (contexto.sp_WebAppInsertaCtmov(num_fol, fec_mov, plazo_pp, refer, ef_cve, tipdoc_cve)).FirstOrDefault();
        }
    }
}
