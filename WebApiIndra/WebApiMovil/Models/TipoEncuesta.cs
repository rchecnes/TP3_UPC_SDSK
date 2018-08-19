using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class TipoEncuesta: Paginacion
    {
        [DataMember]
        public int TEN_ID { get; set; }
        [DataMember]
        public string TEN_Nombre { get; set; }
        [DataMember]
        public int TEN_AnioVigencia { get; set; }
        [DataMember]
        public string TEN_Descripcion { get; set; }
        [DataMember]
        public string TEN_FechaCrecion { get; set; }
        [DataMember]
        public string TEN_UsuarioCreacion { get; set; }
        [DataMember]
        public string TEN_FechaModificacion { get; set; }
        [DataMember]
        public string TEN_UsuarioModificacion { get; set; }
        [DataMember]
        public int TEN_FlagActivo { get; set; }
        [DataMember]
        public int TEN_FlagEnvio { get; set; }
    }
}