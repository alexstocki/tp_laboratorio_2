]using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            : base("Nacionalidad y DNI no se corresponden")
        { }

        public NacionalidadInvalidaException(string mensaje)
            : base(mensaje)
        { }
    }
}
