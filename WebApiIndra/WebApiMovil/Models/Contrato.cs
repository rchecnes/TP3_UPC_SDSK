using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Contrato: Paginacion
    {
        [DataMember]
        public int CON_ID { get; set; }

        [DataMember]
        public int CON_EMP_ID { get; set; }

        [DataMember]
        public string EMP_RazonSocial { get; set; }

        [DataMember]
        public string CON_FechaInicioContrato { get; set; }

        [DataMember]
        public string CON_FechaInicioContratoI { get; set; }

        [DataMember]
        public string CON_FechaFinContrato { get; set; }

        [DataMember]
        public string CON_FechaFinContratoF { get; set; }

        [DataMember]
        public string CON_FechaCreacion { get; set; }

        [DataMember]
        public string CON_FechaModificacion { get; set; }

        [DataMember]
        public string CON_UsuarioCreacion { get; set; }

        [DataMember]
        public int CON_UsuarioModificacion { get; set; }
    }
}