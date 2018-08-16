using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Cargo
    {
        [DataMember]
        public int CAR_ID { get; set; }

        [DataMember]
        public string CAR_Descripcion { get; set; }
    }
}