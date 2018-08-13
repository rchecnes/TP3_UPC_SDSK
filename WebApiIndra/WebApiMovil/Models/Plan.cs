using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Plan
    {
        [DataMember]
        public int iCodPlan { get; set; }

        [DataMember]
        public int idCodTipoPlan { get; set; }

        [DataMember]
        public string vNombre { get; set; }

        [DataMember]
        public Decimal dCantidadGigas { get; set; }

        [DataMember]
        public Decimal dCantidadMinutos { get; set; }

        [DataMember]
        public Decimal dCantidadMsj { get; set; }

        [DataMember]
        public string vNroCelular { get; set; }
    }
}