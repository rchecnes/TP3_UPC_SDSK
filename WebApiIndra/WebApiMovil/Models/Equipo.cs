using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Equipo : Paginacion
    {
        [DataMember]
        public int idCodEquipo { get; set; }

        [DataMember]
        public string NroCelular { get; set; }

        [DataMember]
        public string IMEI { get; set; }

        [DataMember]
        public int iCodMarca{ get; set; }

        [DataMember]
        public string vMarca { get; set; }

        [DataMember]
        public int iCodModelo { get; set; }

        [DataMember]
        public string vModelo{ get; set; }

        [DataMember]
        public int iCodResponsable { get; set; }

        [DataMember]
        public string vReponsableNombre { get; set; }

        [DataMember]
        public string vReponsableApePat { get; set; }

        [DataMember]
        public string vReponsableApeMat { get; set; }

        [DataMember]
        public string vReponsable { get; set; }

        [DataMember]
        public int iCodEncargado { get; set; }

        [DataMember]
        public string vEncargadoNombre { get; set; }

        [DataMember]
        public string vEncargadoApePat { get; set; }

        [DataMember]
        public string vEncargadoApeMat { get; set; }

        [DataMember]
        public string vEncargado { get; set; }

        [DataMember]
        public bool bActivo { get; set; }

        [DataMember]
        public string cEstado { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public List<Accesorio> AccesorioList { get; set; }

        [DataMember]
        public decimal mes1 { get; set; }

        [DataMember]
        public decimal mes2 { get; set; }

        [DataMember]
        public decimal mes3 { get; set; }

        [DataMember]
        public decimal mes4 { get; set; }

        [DataMember]
        public decimal mes5 { get; set; }

        [DataMember]
        public decimal mes6 { get; set; }

        [DataMember]
        public decimal mes7 { get; set; }

        [DataMember]
        public decimal mes8 { get; set; }

        [DataMember]
        public decimal mes9 { get; set; }

        [DataMember]
        public decimal mes10 { get; set; }

        [DataMember]
        public decimal mes11 { get; set; }

        [DataMember]
        public decimal mes12 { get; set; }

    }
}