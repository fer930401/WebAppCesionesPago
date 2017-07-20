using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CesionesPago.Entidades;

namespace CesionesPago.LogicaNegocios
{
    public class LogicaNegocios
    {
        AccesoDatos.AccesoDatos datos;

        public LogicaNegocios()
        {
            datos = new AccesoDatos.AccesoDatos();
        }

        public List<Entidades.xcuser> ListaUsuarios()
        {
            return datos.ListaUsuarios(datos.ListaUser_cve());
        }
        public string Login(string usuario, string pass)
        {
            return datos.Login(usuario, pass);
        }
        public List<WebAppConsultaPagos_Result> ConsultaPagos(string ef_cve, int num_fol)
        {
            return datos.ConsultaPagos(ef_cve, num_fol);
        }
        public WebAppCesionesPago_Result Autorizar(string ef_cve, int tipo_cesion, string tipo_doc, int num_fol, DateTime fecha, string user)
        {
            return datos.Autorizar(ef_cve, tipo_cesion, tipo_doc, num_fol, fecha, user);
        }
    }
}
