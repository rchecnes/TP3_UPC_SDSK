using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    public class UsuarioResponsable:Paginacion
    {
        [DataMember]
        public int RES_ID { get; set; }

        [DataMember]
        public string RES_Login { get; set; }

        [DataMember]
        public string RES_Nombre { get; set; }

        [DataMember]
        public string RES_ApellidoPaterno { get; set; }

        [DataMember]
        public string RES_ApellidoMaterno { get; set; }

        [DataMember]
        public string RES_Email { get; set; }

        [DataMember]
        public int RES_CAR_ID { get; set; }

        [DataMember]
        public string CAR_Descripcion { get; set; }

        [DataMember]
        public int RES_NIV_ID { get; set; }

        [DataMember]
        public string NIV_Descripcion { get; set; }
    }
}