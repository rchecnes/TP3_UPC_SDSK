﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiIndra.Models
{
    [DataContract]
    public class SD_BaseConocimiento
    {
        [DataMember]
        public string NombreBC { get; set; }
    }
}