using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Asignacion:Paginacion
    {
        [DataMember]
        public int idCodAsignacion { get; set; }

        [DataMember]
        public int idCodEquipo { get; set; }

        [DataMember]
        public string NroCelular { get; set; }

        [DataMember]
        public string IMEI { get; set; }

        [DataMember]
        public int iCodMarca { get; set; }

        [DataMember]
        public string vMarca { get; set; }

        [DataMember]
        public int iCodModelo { get; set; }

        [DataMember]
        public string vModelo { get; set; }

        [DataMember]
        public int iCodResponsable { get; set; }

        [DataMember]
        public string vNroDocRepsonsable { get; set; }

        [DataMember]
        public string vNombreResponsable { get; set; }

        [DataMember]
        public string vReponsableNombre { get; set; }

        [DataMember]
        public string vApePatResponsable { get; set; }

        [DataMember]
        public string vApeMatResponsable { get; set; }

        [DataMember]
        public string vReponsable { get; set; }

        [DataMember]
        public int iCodEncargado { get; set; }

        [DataMember]
        public string vNroDocEncargado { get; set; }

        [DataMember]
        public string vNombreEncargado { get; set; }

        [DataMember]
        public string vEncargadoNombre { get; set; }

        [DataMember]
        public string vApePatEncargado { get; set; }

        [DataMember]
        public string vApeMatEncargado { get; set; }

        [DataMember]
        public string vNroCelular { get; set; }

        [DataMember]
        public string dtFechaASignacion { get; set; }

        [DataMember]
        public string vEncargado { get; set; }

        [DataMember]
        public bool bActivo { get; set; }

        [DataMember]
        public string cEstado { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string vAcciones { get; set; }

        [DataMember]
        public int iCodPlan { get; set; }

        [DataMember]
        public int iUsuarioRegistro { get; set; }

        [DataMember]
        public int iOpcion { get; set; }

        [DataMember]
        public bool bError { get; set; }

        [DataMember]
        public string vMensaje { get; set; }

        [DataMember]
        public string vIMEI { get; set; }

        [DataMember]
        public decimal dCantidadGigas { get; set; }

        [DataMember]
        public decimal dCantidadMinutos { get; set; }

        [DataMember]
        public decimal dCantidadMsj { get; set; }

        [DataMember]
        public string vPlan { get; set; }

        [DataMember]
        public string vDependencia { get; set; }

        [DataMember]
        public string vUnidad { get; set; }

        [DataMember]
        public string vNombreDocumento { get; set; }

        [DataMember]
        public string vBase64Reporte { get; set; }

       

        [DataMember]
        public Equipo equipo { get; set; }

        [DataMember]
        public Accesorio accesorio { get; set; }

    }
}