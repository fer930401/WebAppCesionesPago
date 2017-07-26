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
        CesionesEntities contexto;

        public AccesoDatos()
        {
            //inicializacion de la variable contexto
            contexto = new CesionesEntities();
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
        public List<WebAppConsultaPagos_Result> ConsultaPagos(string ef_cve, int num_fol)
        {
            List<WebAppConsultaPagos_Result> pagos = contexto.WebAppConsultaPagos(ef_cve, num_fol).ToList();
            SqlConnection.ClearAllPools();
            return pagos;
        }
        public WebAppCesionesPago_Result Autorizar(string ef_cve, int tipo_cesion, string tipo_doc, int num_fol, DateTime fecha, string user)
        {
            WebAppCesionesPago_Result resultado = contexto.WebAppCesionesPago(ef_cve, tipo_cesion, tipo_doc, num_fol, fecha, user).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
        public WebAppCesionesConfirming_Result Confirming(short sw, string ef_cve)
        {
            WebAppCesionesConfirming_Result resultado = contexto.WebAppCesionesConfirming(sw, ef_cve).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
    }
}
