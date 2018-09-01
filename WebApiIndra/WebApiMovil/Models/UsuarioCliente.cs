using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class UsuarioCliente
    {
        [DataMember]
        public int USU_ID { get; set; }

        [DataMember]
        public string USU_Nombre { get; set; }
    }
}