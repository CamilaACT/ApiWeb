﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProyecto.model.Response
{
    public class Respuesta
    {
        public int CodigoError { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
