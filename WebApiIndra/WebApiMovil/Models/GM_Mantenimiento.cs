using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Mantenimiento
    {
        [DataMember]
        public int IdMantenimiento { get; set; }

        [DataMember]
        public string NomMantenimiento { get; set; }
    }
}