using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int CodigoTicket { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public DateTime FechaVigencia { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}