using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Trabajador
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string cod_area { get; set; }

        [DataMember]
        public string dsc_area { get; set; }

        [DataMember]
        public string cod_empresa { get; set; }

        [DataMember]
        public string Tip_Personal { get; set; }

        [DataMember]
        public string cod_Trabajador { get; set; }

        [DataMember]
        public string dsc_paterno { get; set; }

        [DataMember]
        public string dsc_materno { get; set; }

        [DataMember]
        public string dsc_nombres { get; set; }

        [DataMember]
        public string cod_estado { get; set; }

        [DataMember]
        public string flg_activo { get; set; }

        [DataMember]
        public string cod_sexo { get; set; }

        [DataMember]
        public string cod_tipo_documento { get; set; }

        [DataMember]
        public string num_documento { get; set; }

        [DataMember]
        public string cod_dependencia { get; set; }

        [DataMember]
        public string dsc_cargo { get; set; }

        [DataMember]
        public string Nom_Trabajador { get; set; }

        [DataMember]
        public string vAnexo { get; set; }

        [DataMember]
        public string movil_institu { get; set; }

        [DataMember]
        public string Email_institu { get; set; }

        [DataMember]
        public string Usuario_institu { get; set; }
    }
}