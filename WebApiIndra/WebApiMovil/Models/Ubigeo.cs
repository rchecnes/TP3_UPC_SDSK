using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Ubigeo
    {
        [DataMember]
        public Int64 iCodDepartamento { get; set; }

        [DataMember]
        public string DEPA_DESCRIPCION { get; set; }

        [DataMember]
        public int iCodProvincia { get; set; }

        [DataMember]
        public string prov_descripcion { get; set; }

        [DataMember]
        public int dist_id { get; set; }

        [DataMember]
        public string dist_descripcion { get; set; }

        [DataMember]
        public int iCodLocalidad { get; set; }

        [DataMember]
        public string Localidad { get; set; }

        [DataMember]
        public string dist_codref { get; set; }

        [DataMember]
        public string DEPA_CODREF { get; set; }

        [DataMember]
        public string prov_codref { get; set; }
    }
}