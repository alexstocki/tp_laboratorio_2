using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException()
            : base("Alumno repetido")
        { }

        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        { }
    }
}
