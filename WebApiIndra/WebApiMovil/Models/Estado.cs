using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Estado
    {
        [DataMember]
        public int EST_ID { get; set; }

        [DataMember]
        public string EST_Descripcion { get; set; }
    }
}