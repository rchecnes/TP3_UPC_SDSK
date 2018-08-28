using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Prioridad
    {
        [DataMember]
        public int PRI_ID { get; set; }

        [DataMember]
        public string PRI_Descripcion { get; set; }
    }
}