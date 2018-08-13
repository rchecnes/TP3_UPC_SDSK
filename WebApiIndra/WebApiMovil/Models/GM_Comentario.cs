using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Comentario
    {
        [DataMember]
        public int IdComentario { get; set; }

        [DataMember]
        public string DesComentario { get; set; }

        [DataMember]
        public string FeCreComentario { get; set; }

        [DataMember]
        public int IdTicket { get; set; }

        [DataMember]
        public int IdEmpleado { get; set; }

        [DataMember]
        public string NomEmpleado { get; set; }
    }
}