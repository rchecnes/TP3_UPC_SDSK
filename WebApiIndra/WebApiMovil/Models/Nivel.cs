using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Nivel
    {
        [DataMember]
        public int NIV_ID { get; set; }

        [DataMember]
        public string NIV_Descripcion { get; set; }
    }
}