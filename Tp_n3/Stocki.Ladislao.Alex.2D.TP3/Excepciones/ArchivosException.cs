using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException()
            : base("Error con el archivo")
        { }

        public ArchivosException(Exception inner)
            : base(inner.Message, inner)
        { }

        public ArchivosException(string mensaje, Exception inner)
            : base(mensaje, inner)
        { }
    }
}
