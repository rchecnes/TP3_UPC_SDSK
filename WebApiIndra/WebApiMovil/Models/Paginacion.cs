using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Paginacion
    {
        [DataMember]
        public int iRecordCount { get; set; }
        [DataMember]
        public int iPageCount { get; set; }
        [DataMember]
        public int iCurrentPage { get; set; }
        [DataMember]
        public string pvSortColumn { get; set; }
        [DataMember]
        public string pvSortOrder { get; set; }
        [DataMember]
        public int piPageSize { get; set; }
        [DataMember]
        public int sEcho { get; set; }
        [DataMember]
        public int draw { get; set; }
        [DataMember]
        public int iTotalRecords { get; set; }
        [DataMember]
        public int iTotalDisplayRecords { get; set; }
    }
}