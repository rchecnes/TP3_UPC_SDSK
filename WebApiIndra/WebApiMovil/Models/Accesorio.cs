using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Accesorio:Paginacion
    {
        [DataMember]
        public int iTotalRecords { get; set; }

        [DataMember]
        public int idCodEquipoDet { get; set; }

        [DataMember]
        public int idCodEquipo { get; set; }

        [DataMember]
        public int idCodAccesorio { get; set; }

        [DataMember]
        public int iOpcion { get; set; }

        [DataMember]
        public string vAccesorio { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string cEstado { get; set; }

        [DataMember]
        public string vAcciones { get; set; }

        [DataMember]
        public bool bError { get; set; }

        [DataMember]
        public string vMensaje { get; set; }

        [DataMember]
        public string vObservacion { get; set; }

        [DataMember]
        public string vArchivo { get; set; }

        [DataMember]
        public decimal dMontoCargador { get; set; }

        [DataMember]
        public decimal dMontoAudifonos { get; set; }

        [DataMember]
        public decimal dMontoAdaptador { get; set; }

        [DataMember]
        public decimal dMontoCableDatos { get; set; }

        [DataMember]
        public decimal dMontoSimCard { get; set; }
    }
}