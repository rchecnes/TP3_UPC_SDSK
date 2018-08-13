using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_ListadoTicket : Paginacion
    {
        [DataMember]
        public int IdTicket { get; set; }

        [DataMember]
        public string NomMantenimiento { get; set; }

        [DataMember]
        public string FeCreTicket { get; set; }

        [DataMember]
        public string FeEnTicket { get; set; }

        [DataMember]
        public string NomCliente { get; set; }

        [DataMember]
        public string NomEstado { get; set; }

        [DataMember]
        public string NomProyecto { get; set; }

        [DataMember]
        public string NomPrioridad { get; set; }

        [DataMember]
        public int IdEstado { get; set; }

        [DataMember]
        public int IdEmpleado { get; set; }

        [DataMember]
        public string NomEmpleado { get; set; }

        [DataMember]
        public string DesTicket { get; set; }

        [DataMember]
        public int IdPrioridad { get; set; }

        [DataMember]
        public int IdMantenimiento { get; set; }


    }
}