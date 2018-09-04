using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class ContratoSLA
    {
        [DataMember]
        public int CSL_ID { get; set; }

        [DataMember]
        public int CSL_CON_ID { get; set; }

        [DataMember]
        public int CSL_SLA_ID { get; set; }

        [DataMember]
        public int CSL_EMP_ID { get; set; }

        [DataMember]
        public string SLA_Descripcion { get; set; }

        [DataMember]
        public int CSL_SER_ID { get; set; }

        [DataMember]
        public string SER_Descripcion { get; set; }

        [DataMember]
        public decimal CSL_PorcentajeMedicion { get; set; }

        [DataMember]
        public decimal CSL_Penalidad { get; set; }

        [DataMember]
        public string CSL_FechaCreacion { get; set; }

        [DataMember]
        public string CSL_FechaModificacion { get; set; }

        [DataMember]
        public string CSL_UsuarioCreacion { get; set; }

        [DataMember]
        public string CSL_UsuarioModificacion { get; set; }

        [DataMember]
        public List<RepMonitoreo> Medicion { get; set; }
    }
}