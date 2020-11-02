using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            : base("DNI invalido") 
        { }
        
        public DniInvalidoException(Exception inner)
        : base(inner.Message, inner)
        { }

        public DniInvalidoException(string mensaje)
        : base(mensaje)
        { }

        public DniInvalidoException(string mensaje, Exception inner)
        : base(mensaje, inner) 
        { }
    }
}
