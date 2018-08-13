using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    public class GM_ListadoActividad
    {
        [DataMember]
        public int IdActividad { get; set; }

        [DataMember]
        public string NomActividad { get; set; }

        [DataMember]
        public decimal PorAvanActividad { get; set; }

        [DataMember]
        public decimal DurActividad { get; set; }

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