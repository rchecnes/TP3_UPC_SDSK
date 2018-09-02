using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class HistorialTicket
    {
        [DataMember]
        public int HIS_ID { get; set; }

        [DataMember]
        public int HIS_TIC_ID { get; set; }

        [DataMember]
        public int HIS_PRI_ID { get; set; }

        [DataMember]
        public string PRI_Descripcion { get; set; }

        [DataMember]
        public int HIS_PRO_ID { get; set; }

        [DataMember]
        public int HIS_SER_ID { get; set; }

        [DataMember]
        public int HIS_RES_ID { get; set; }

        [DataMember]
        public string RES_Nombre { get; set; }

        [DataMember]
        public string HIS_FechaCambio { get; set; }

        [DataMember]
        public string HIS_Descripcion { get; set; }

        [DataMember]
        public int HIS_RutaInforme { get; set; }
    }
}