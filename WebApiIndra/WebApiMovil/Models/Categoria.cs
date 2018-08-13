using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Categoria
    {
        [DataMember]
        public int CAT_ID { get; set; }

        [DataMember]
        public string CAT_Descripcion { get; set; }
    }
}