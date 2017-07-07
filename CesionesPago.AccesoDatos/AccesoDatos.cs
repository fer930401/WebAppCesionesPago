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

        public sp_WebAppInsertaCtmov_Result insertCtmov(int? num_fol, DateTime fec_mov, int? plazo_pp, string refer, string ef_cve, string tipdoc_cve, string user, string ef_cved, string tipdoc_cved, int? num_fold, decimal? dato10, string tm, string nombre, short? statusd)
        {
            return (contexto.sp_WebAppInsertaCtmov(num_fol, fec_mov, plazo_pp, refer, ef_cve, tipdoc_cve, user,ef_cved,tipdoc_cved,num_fold,dato10,tm,nombre,statusd)).FirstOrDefault();
        }

        public sp_WebAppActualizaCtdmov_Result actualizaCtdmov(string ef_cve, string tipo_doc, int num_fol, short num_reng , short PI_OPCION)
        {
            return (contexto.sp_WebAppActualizaCtdmov(ef_cve, tipo_doc, num_fol, num_reng, PI_OPCION).FirstOrDefault());
        }
        public void confirmar(string ef_cve, string tipdoc, int folio, short status, bool sw_si_no, bool sw_term, DateTime fecha, string obs, string id)
        {
            contexto.sp_gnewsts(ef_cve, tipdoc, folio, status, sw_si_no, sw_term, fecha, obs, id);
        }
        public List<string> ListaUser_cve()
        {
            return ((from u in contexto.xcdconapl_cl where u.sp_cve.Equals("CesionPag") select u.spd_cve).ToList());
        }
        public List<xcuser> ListaUsuarios(List<string> Usuarios)
        {
            return (from u in contexto.xcuser where Usuarios.Contains(u.user_cve) && u.ef_cve == "001" select u).ToList();
        }
        public string Login(string usuario, string pass)
        {
            string resultado = "";
            var consultaLogin = (from u in contexto.xcuser
                                 where u.user_cve.Equals(usuario)
                                         && u.password.Equals(pass)
                                 select u).FirstOrDefault();
            if (consultaLogin == null)
            {
                resultado = null;
            }
            else
            {
                resultado = consultaLogin.user_cve;
            }
            return resultado;
        }
        public List<sp_WebAppConsultaPagos_Result> ConsultaPagos(string ef_cve, string tip_doc, string Tipo_Pago)
        {
            return (contexto.sp_WebAppConsultaPagos(ef_cve, tip_doc, 0, Tipo_Pago).ToList());
        }
    }
}
