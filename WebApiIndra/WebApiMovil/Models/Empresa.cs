using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public int EMP_ID { get; set; }

        [DataMember]
        public string EMP_RUC { get; set; }

        [DataMember]
        public string EMP_RazonSocial { get; set; }

        [DataMember]
        public int value { get; set; }

        [DataMember]
        public string label { get; set; }
    }
}