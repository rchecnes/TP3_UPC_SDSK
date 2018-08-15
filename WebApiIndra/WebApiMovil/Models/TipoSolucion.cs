using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class TipoSolucion: Paginacion
    {
        [DataMember]
        public int SOL_ID { get; set; }

        [DataMember]
        public string SOL_Nombre { get; set; }

        [DataMember]
        public string SOL_RutaArchivo { get; set; }

        [DataMember]
        public string SOL_NombreArchivo { get; set; }

        [DataMember]
        public string SOL_Descripcion { get; set; }

        [DataMember]
        public string SOL_PalabraClave { get; set; }

        [DataMember]
        public string SOL_Comentario { get; set; }

        [DataMember]
        public string SOL_FechaCreacion { get; set; }

        [DataMember]
        public string SOL_FechaModificacion { get; set; }

        [DataMember]
        public string SOL_UsuarioCreacion { get; set; }

        [DataMember]
        public string SOL_UsuarioModificacion { get; set; }

        [DataMember]
        public int SOL_PROB_ID { get; set; }

        [DataMember]
        public string CAT_Descripcion { get; set; }
        
        [DataMember]
        public int SOL_CAT_ID { get; set; }
    }
}