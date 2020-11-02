using System;
using System.Security.Cryptography;
using System.Text;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido { get { return this.apellido; } set { this.apellido = this.ValidarNombreApellido(value); } }

        public int DNI { get { return this.dni; } set { this.dni = this.ValidarDni(this.Nacionalidad, value); } }

        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }

        public string Nombre { get { return this.nombre; } set { this.nombre = this.ValidarNombreApellido(value); } }

        public string StringToDNI 
        { 
            set 
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            } 
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor sin parametros
        /// necesario para la serializacion
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Retorna los datos de la persona
        /// </summary>
        /// <returns>string con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder persona = new StringBuilder();
            persona.AppendFormat("{0}, {1}\nDNI: {2} Nacionalidad: {3}", this.Apellido, 
                this.Nombre, this.DNI, this.Nacionalidad);
            return persona.ToString();
        }

        /// <summary>
        /// Valida que la nacionalidad y el numero de dni se correspondan
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">numero de dni</param>
        /// <returns>regresa el numero de dni en caso de ser correcto, 
        /// se lanza error caso contrario</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato  > 89999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Valida que el string dato este compuesto por numeros 
        /// y valida la relacion nacionalidad-dni 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length >= 1 && dato.Length <= 8)
            {
                foreach (char caracter in dato)
                {
                    if (!(char.IsNumber(caracter)))
                    {
                        throw new DniInvalidoException();
                    }
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
            return this.ValidarDni(nacionalidad, int.Parse(dato));
        }

        /// <summary>
        /// Valida que el nombre y apellido solo contengan caracteres validos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>parametro dato si cumple las condiones, caso contrario string vacio</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char caracter in dato)
            {
                if (!(char.IsLetter(caracter)) && !(caracter != ' '))
                {
                    return "";
                }
            }
            return dato;
        }
        #endregion
 
        public enum ENacionalidad
        {
            Argentino, 
            Extranjero
        }
    }
}
