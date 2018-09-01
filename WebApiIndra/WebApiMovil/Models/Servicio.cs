using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Servicio
    {
        [DataMember]
        public int SER_ID { get; set; }

        [DataMember]
        public string SER_Descripcion { get; set; }
    }
}