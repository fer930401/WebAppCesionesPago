﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CesionesPago.Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class skytexEntities : DbContext
    {
        public skytexEntities()
            : base("name=skytexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<xufolios> xufolios { get; set; }
        public virtual DbSet<xcdconapl_cl> xcdconapl_cl { get; set; }
        public virtual DbSet<xcuser> xcuser { get; set; }
    
        public virtual ObjectResult<qcomcve1_Result> qcomcve1(string tipo)
        {
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<qcomcve1_Result>("qcomcve1", tipoParameter);
        }
    
        public virtual ObjectResult<sp_lisdetctmov7_Result> sp_lisdetctmov7(string ef_cve, string tipo_doc, string tipo_docp, Nullable<int> num_fol)
        {
            var ef_cveParameter = ef_cve != null ?
                new ObjectParameter("ef_cve", ef_cve) :
                new ObjectParameter("ef_cve", typeof(string));
    
            var tipo_docParameter = tipo_doc != null ?
                new ObjectParameter("tipo_doc", tipo_doc) :
                new ObjectParameter("tipo_doc", typeof(string));
    
            var tipo_docpParameter = tipo_docp != null ?
                new ObjectParameter("tipo_docp", tipo_docp) :
                new ObjectParameter("tipo_docp", typeof(string));
    
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_lisdetctmov7_Result>("sp_lisdetctmov7", ef_cveParameter, tipo_docParameter, tipo_docpParameter, num_folParameter);
        }
    
        public virtual ObjectResult<sp_WebAppInsertaCtmov_Result> sp_WebAppInsertaCtmov(Nullable<int> num_fol, Nullable<System.DateTime> fec_mov, Nullable<int> plazo_pp, string refer, string ef_cve, string tipdoc_cve, string user_cve, string ef_cved, string tipdoc_cved, Nullable<int> num_fold, Nullable<decimal> dato10, string tm, string nombre, Nullable<short> statusd)
        {
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var fec_movParameter = fec_mov.HasValue ?
                new ObjectParameter("fec_mov", fec_mov) :
                new ObjectParameter("fec_mov", typeof(System.DateTime));
    
            var plazo_ppParameter = plazo_pp.HasValue ?
                new ObjectParameter("plazo_pp", plazo_pp) :
                new ObjectParameter("plazo_pp", typeof(int));
    
            var referParameter = refer != null ?
                new ObjectParameter("refer", refer) :
                new ObjectParameter("refer", typeof(string));
    
            var ef_cveParameter = ef_cve != null ?
                new ObjectParameter("ef_cve", ef_cve) :
                new ObjectParameter("ef_cve", typeof(string));
    
            var tipdoc_cveParameter = tipdoc_cve != null ?
                new ObjectParameter("tipdoc_cve", tipdoc_cve) :
                new ObjectParameter("tipdoc_cve", typeof(string));
    
            var user_cveParameter = user_cve != null ?
                new ObjectParameter("user_cve", user_cve) :
                new ObjectParameter("user_cve", typeof(string));
    
            var ef_cvedParameter = ef_cved != null ?
                new ObjectParameter("ef_cved", ef_cved) :
                new ObjectParameter("ef_cved", typeof(string));
    
            var tipdoc_cvedParameter = tipdoc_cved != null ?
                new ObjectParameter("tipdoc_cved", tipdoc_cved) :
                new ObjectParameter("tipdoc_cved", typeof(string));
    
            var num_foldParameter = num_fold.HasValue ?
                new ObjectParameter("num_fold", num_fold) :
                new ObjectParameter("num_fold", typeof(int));
    
            var dato10Parameter = dato10.HasValue ?
                new ObjectParameter("dato10", dato10) :
                new ObjectParameter("dato10", typeof(decimal));
    
            var tmParameter = tm != null ?
                new ObjectParameter("tm", tm) :
                new ObjectParameter("tm", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var statusdParameter = statusd.HasValue ?
                new ObjectParameter("statusd", statusd) :
                new ObjectParameter("statusd", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_WebAppInsertaCtmov_Result>("sp_WebAppInsertaCtmov", num_folParameter, fec_movParameter, plazo_ppParameter, referParameter, ef_cveParameter, tipdoc_cveParameter, user_cveParameter, ef_cvedParameter, tipdoc_cvedParameter, num_foldParameter, dato10Parameter, tmParameter, nombreParameter, statusdParameter);
        }
    
        public virtual int sp_gnewsts(string ef_cve, string tipdoc, Nullable<int> folio, Nullable<short> status, Nullable<bool> sw_si_no, Nullable<bool> sw_term, Nullable<System.DateTime> fecha, string obs, string id)
        {
            var ef_cveParameter = ef_cve != null ?
                new ObjectParameter("ef_cve", ef_cve) :
                new ObjectParameter("ef_cve", typeof(string));
    
            var tipdocParameter = tipdoc != null ?
                new ObjectParameter("tipdoc", tipdoc) :
                new ObjectParameter("tipdoc", typeof(string));
    
            var folioParameter = folio.HasValue ?
                new ObjectParameter("folio", folio) :
                new ObjectParameter("folio", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(short));
    
            var sw_si_noParameter = sw_si_no.HasValue ?
                new ObjectParameter("sw_si_no", sw_si_no) :
                new ObjectParameter("sw_si_no", typeof(bool));
    
            var sw_termParameter = sw_term.HasValue ?
                new ObjectParameter("sw_term", sw_term) :
                new ObjectParameter("sw_term", typeof(bool));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var obsParameter = obs != null ?
                new ObjectParameter("obs", obs) :
                new ObjectParameter("obs", typeof(string));
    
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_gnewsts", ef_cveParameter, tipdocParameter, folioParameter, statusParameter, sw_si_noParameter, sw_termParameter, fechaParameter, obsParameter, idParameter);
        }
    
        public virtual ObjectResult<sp_WebAppActualizaCtdmov_Result> sp_WebAppActualizaCtdmov(string ef_cve, string tipo_doc, Nullable<int> num_fol, Nullable<short> num_reng, Nullable<short> pI_OPCION)
        {
            var ef_cveParameter = ef_cve != null ?
                new ObjectParameter("ef_cve", ef_cve) :
                new ObjectParameter("ef_cve", typeof(string));
    
            var tipo_docParameter = tipo_doc != null ?
                new ObjectParameter("tipo_doc", tipo_doc) :
                new ObjectParameter("tipo_doc", typeof(string));
    
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var num_rengParameter = num_reng.HasValue ?
                new ObjectParameter("num_reng", num_reng) :
                new ObjectParameter("num_reng", typeof(short));
    
            var pI_OPCIONParameter = pI_OPCION.HasValue ?
                new ObjectParameter("PI_OPCION", pI_OPCION) :
                new ObjectParameter("PI_OPCION", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_WebAppActualizaCtdmov_Result>("sp_WebAppActualizaCtdmov", ef_cveParameter, tipo_docParameter, num_folParameter, num_rengParameter, pI_OPCIONParameter);
        }
    
        public virtual ObjectResult<sp_WebAppConsultaPagos_Result> sp_WebAppConsultaPagos(string ef_cve, string tipdoc_cve, Nullable<int> num_fol, string tipoPago)
        {
            var ef_cveParameter = ef_cve != null ?
                new ObjectParameter("ef_cve", ef_cve) :
                new ObjectParameter("ef_cve", typeof(string));
    
            var tipdoc_cveParameter = tipdoc_cve != null ?
                new ObjectParameter("tipdoc_cve", tipdoc_cve) :
                new ObjectParameter("tipdoc_cve", typeof(string));
    
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var tipoPagoParameter = tipoPago != null ?
                new ObjectParameter("tipoPago", tipoPago) :
                new ObjectParameter("tipoPago", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_WebAppConsultaPagos_Result>("sp_WebAppConsultaPagos", ef_cveParameter, tipdoc_cveParameter, num_folParameter, tipoPagoParameter);
        }
    }
}
