using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Prioridad
    {
        [DataMember]
        public int IdPrioridad { get; set; }

        [DataMember]
        public string NomPrioridad { get; set; }

        [DataMember]
        public string DesPrioridad { get; set; }
    }
}