﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComercioEletronico.Models
{
    public class Administrativo
    {
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}