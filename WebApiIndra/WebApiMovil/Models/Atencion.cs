using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Atencion
    {
        [DataMember]
        public int ATE_ID { get; set; }

        [DataMember]
        public int ATE_TIC_ID { get; set; }

        [DataMember]
        public int ATE_RES_ID { get; set; }

        [DataMember]
        public int ATE_RST_ID { get; set; }

        [DataMember]
        public string ATE_FechaAsignacion { get; set; }
        [DataMember]
        public string ATE_FechaInicio { get; set; }
        [DataMember]
        public string ATE_FechaFin { get; set; }
        [DataMember]
        public string ATE_FechaCierre { get; set; }
        [DataMember]
        public string ATE_FechaAtencion { get; set; }
        [DataMember]
        public int ATE_PRI_ID { get; set; }
        [DataMember]
        public string ATE_TIC_Descripcion { get; set; }
        [DataMember]
        public string ATE_FechaRegistro { get; set; }
        [DataMember]
        public string ATE_Descripcion { get; set; }
    }
}