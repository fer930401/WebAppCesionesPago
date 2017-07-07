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

        public Entidades.sp_WebAppInsertaCtmov_Result insertCtmov(int? num_fol, DateTime fec_mov, int? plazo_pp, string refer, string ef_cve, string tipdoc_cve, string user, string ef_cved, string tipdoc_cved, int? num_fold, decimal? dato10, string tm, string nombre, short? statusd)
        {
            return datos.insertCtmov(num_fol, fec_mov, plazo_pp, refer, ef_cve, tipdoc_cve, user, ef_cved, tipdoc_cved, num_fold, dato10, tm, nombre, statusd);
        }

        public Entidades.sp_WebAppActualizaCtdmov_Result actualizaCtdmov(string ef_cve, string tipo_doc, int num_fol, short num_reng, short PI_OPCION)
        {
            return datos.actualizaCtdmov(ef_cve, tipo_doc, num_fol, num_reng, PI_OPCION);
        }

        public void confirmar(string ef_cve, string tipdoc, int folio, short status, bool sw_si_no, bool sw_term, DateTime fecha, string obs, string id)
        {
            datos.confirmar(ef_cve, tipdoc, folio, status, sw_si_no, sw_term, fecha, obs, id);
        }
        public List<Entidades.xcuser> ListaUsuarios()
        {
            return datos.ListaUsuarios(datos.ListaUser_cve());
        }
        public string Login(string usuario, string pass)
        {
            return datos.Login(usuario, pass);
        }
        public List<Entidades.sp_WebAppConsultaPagos_Result> ConsultaPagos(string ef_cve, string tip_doc, string tipoPago)
        {
            return datos.ConsultaPagos(ef_cve, tip_doc, tipoPago);
        }
    }
}
