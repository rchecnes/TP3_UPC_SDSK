using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int USUS_ID { get; set; }

        [DataMember]
        public string USUS_Login { get; set; }

        [DataMember]
        public string USUS_Password { get; set; }

        [DataMember]
        public string USUS_Nombre { get; set; }

        [DataMember]
        public int USUS_CAR_ID { get; set; }

        [DataMember]
        public string USUS_CAR_Nombre { get; set; }

        [DataMember]
        public string USUS_Tipo { get; set; }
    }
}