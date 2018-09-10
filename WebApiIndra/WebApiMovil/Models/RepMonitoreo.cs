using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class RepMonitoreo
    {
        [DataMember]
        public int REP_Periodo { get; set; }

        [DataMember]
        public int REP_Cumple { get; set; }

        [DataMember]
        public decimal REP_Logro { get; set; }

        [DataMember]
        public string REP_Descripcion { get; set; }

        [DataMember]
        public int REP_Anio { get; set; }

    }
}