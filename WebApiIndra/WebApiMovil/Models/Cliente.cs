using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Cliente:Paginacion
    {

        [DataMember]
        public int CodigoCliente { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Direccion { get; set; }
    }
}