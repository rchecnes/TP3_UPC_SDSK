using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class TipoProblema
    {
        [DataMember]
        public int PROB_ID { get; set; }

        [DataMember]
        public string PROB_Descripcion { get; set; }

        [DataMember]
        public int SER_ID { get; set; }
    }
}