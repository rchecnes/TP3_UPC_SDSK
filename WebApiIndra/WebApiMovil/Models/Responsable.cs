using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Responsable
    {
        [DataMember]
        public string NroDocResponsable { get; set; }

        [DataMember]
        public string vResponsable { get; set; }

        [DataMember]
        public string vApePaterno { get; set; }

        [DataMember]
        public string vApeMaterno { get; set; }

        [DataMember]
        public string vNombres { get; set; }
    }
}