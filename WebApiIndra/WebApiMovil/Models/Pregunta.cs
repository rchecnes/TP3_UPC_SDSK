using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Pregunta
    {
        [DataMember]
        public int PRE_ID { get; set; }
        [DataMember]
        public string PRE_Descripcion { get; set; }
        [DataMember]
        public int PRE_TipoControl { get; set; }
        [DataMember]
        public int PRE_FlagActivo { get; set; }
        [DataMember]
        public string label { get; set; }
        [DataMember]
        public int value { get; set; }
    }

}