﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class ContratoSLA
    {
        [DataMember]
        public int CSL_ID { get; set; }

        [DataMember]
        public int CSL_CON_ID { get; set; }

        [DataMember]
        public int CSL_SLA_ID { get; set; }

        [DataMember]
        public int CSL_SER_ID { get; set; }

        [DataMember]
        public double CSL_PorcentajeMedicion { get; set; }

        [DataMember]
        public double CSL_Penalidad { get; set; }

        [DataMember]
        public string CSL_FechaCreacion { get; set; }

        [DataMember]
        public string CSL_FechaModificacion { get; set; }

        [DataMember]
        public string CSL_UsuarioCreacion { get; set; }

        [DataMember]
        public string CSL_UsuarioModificacion { get; set; }
    }
}