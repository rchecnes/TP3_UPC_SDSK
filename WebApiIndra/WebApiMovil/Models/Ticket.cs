using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Ticket: Paginacion
    {
        [DataMember]
        public int TIC_ID { get; set; }

        [DataMember]
        public string TIC_CODE { get; set; }        

        [DataMember]
        public int TIC_PROB_ID { get; set; }

        [DataMember]
        public int TIC_PRI_ID { get; set; }
        
        [DataMember]
        public int TIC_SOL_ID { get; set; }

        [DataMember]
        public int TIC_SER_ID { get; set; }

        [DataMember]
        public int TIC_EMP_ID { get; set; }

        [DataMember]
        public string EMP_Nombre { get; set; }

        [DataMember]
        public string EMP_RazonSocial { get; set; }

        [DataMember]
        public int TIC_USU_ID { get; set; }

        [DataMember]
        public string USU_IDLogin { get; set; }

        [DataMember]
        public string USU_Nombre { get; set; }

        [DataMember]
        public int TIC_RES_ID { get; set; }

        [DataMember]
        public string RES_Nombre { get; set; }

        [DataMember]
        public string TIC_Descripcion { get; set; }

        [DataMember]
        public string TIC_FechaRegistro { get; set; }

        [DataMember]
        public string TIC_FechaInicio { get; set; }

        [DataMember]
        public string TIC_FechaFin { get; set; }

        [DataMember]
        public string TIC_FechaCierre { get; set; }

        [DataMember]
        public int TIC_EST_ID { get; set; }

        [DataMember]
        public string EST_Descrpcion { get; set; }

        [DataMember]
        public int TIC_ENC_ID { get; set; }
    }
}