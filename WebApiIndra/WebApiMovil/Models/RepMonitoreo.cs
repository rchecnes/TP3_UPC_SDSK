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
        public string REP_Periodo { get; set; }

        [DataMember]
        public decimal REP_Meta { get; set; }

        [DataMember]
        public decimal REP_Logro { get; set; }

    }
}