using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Encargado
    {
        [DataMember]
        public string NroDocEncargado{ get; set; }

        [DataMember]
        public string vEncargado { get; set; }

        [DataMember]
        public string vApePaternoEnc { get; set; }

        [DataMember]
        public string vApeMaternoEnc { get; set; }
    }
}