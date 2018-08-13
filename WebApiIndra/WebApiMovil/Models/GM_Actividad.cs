using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Actividad
    {
        [DataMember]
        public int IdActividad { get; set; }

        [DataMember]
        public string NomActividad { get; set; }

        [DataMember]
        public float PorAvanActividad { get; set; }

        [DataMember]
        public float DurActividad { get; set; }

        [DataMember]
        public string FeCreActividad { get; set; }

        [DataMember]
        public string FeIniActividad { get; set; }

        [DataMember]
        public string FeFinActividad { get; set; }

        [DataMember]
        public float IdTicket { get; set; }

        [DataMember]
        public float IdCreEmpleado { get; set; }

        [DataMember]
        public float IdModEmpleado { get; set; }
    }
}