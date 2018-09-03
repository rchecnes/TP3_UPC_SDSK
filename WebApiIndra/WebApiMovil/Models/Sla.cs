using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Sla
    {
        [DataMember]
        public int SLA_ID { get; set; }

        [DataMember]
        public string SLA_Descripcion { get; set; }

        [DataMember]
        public string SLA_NomSistema { get; set; }
    }
}