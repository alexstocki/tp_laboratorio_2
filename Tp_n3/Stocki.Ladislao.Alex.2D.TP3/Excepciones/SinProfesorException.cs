using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
            : base("No hay profesor disponible para dar la clase")
        { }

        public SinProfesorException(string mensaje)
            : base(mensaje)
        { }
    }
}
