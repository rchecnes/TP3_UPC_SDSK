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
        public int PRO_ID { get; set; }

        [DataMember]
        public string PRO_Descripcion { get; set; }

        [DataMember]
        public int SER_ID { get; set; }
    }
}