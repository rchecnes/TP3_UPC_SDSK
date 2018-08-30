using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class EncuestaRespuesta
    {
        [DataMember]
        public int ERE_ID { get; set; }

        [DataMember]
        public int ERE_ENC_ID { get; set; }

        [DataMember]
        public DateTime ERE_FechaRespuesta { get; set; }

        [DataMember]
        public List<TipoEncuestaPregunta> Pregunta{ get; set; }

        [DataMember]
        public string ENC_Titulo { get; set; }

        [DataMember]
        public string ENC_Descripcion { get; set; }

        [DataMember]
        public int ENC_TUS_ID { get; set; }

        [DataMember]
        public int ENC_EMP_ID { get; set; }

        [DataMember]
        public string ENC_UsuarioCreacion { get; set; }

        [DataMember]
        public int TIC_ID { get; set; }
    }
}