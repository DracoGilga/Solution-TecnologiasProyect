using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model
{
    public class Mensaje
    {
        public Boolean error { get; set; }
        public string mensaje { get; set; }
        public Academico usuarioAutenticado { get; set; }
    }
}