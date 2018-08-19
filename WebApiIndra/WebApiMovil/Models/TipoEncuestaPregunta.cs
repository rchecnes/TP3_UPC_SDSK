using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class TipoEncuestaPregunta
    {
        [DataMember]
        public int TEP_ID { get; set; }
        [DataMember]
        public int TEP_PRE_ID { get; set; }
        [DataMember]
        public int TEP_TEN_ID { get; set; }
        [DataMember]
        public int TEP_FlagActivo { get; set; }
        [DataMember]
        public string PRE_Descripcion { get; set; }
        [DataMember]
        public int PRE_TipoControl { get; set; }

        
    }
}