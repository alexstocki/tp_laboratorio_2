using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos 
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Métodos
        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Devuelve string con los datos del alumno
        /// </summary>
        /// <returns>string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder alumno = new StringBuilder();
            alumno.AppendLine(base.MostrarDatos());
            alumno.AppendFormat("Estado de cuenta: {0}\n{1}", this.estadoCuenta, this.ParticiparEnClase());
            return alumno.ToString();
        }

        /// <summary>
        /// Verifica si un alumno toma la clase recibida por parametro
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns>True si toma la clase, False caso contario</returns>
        public static bool operator ==(Alumno alumno, EClases clase)
        {
            if (alumno.claseQueToma == clase)
            {
                if (!(alumno.estadoCuenta == EEstadoCuenta.Deudor))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno no toma la clase recibida por parametro
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns>True si no la toma, False caso contrario</returns>
        public static bool operator !=(Alumno alumno, EClases clase)
        {
            return alumno.claseQueToma != clase;
        }

        /// <summary>
        /// Devuelve string con la clase que toma el alumno
        /// </summary>
        /// <returns>string con el nombre de la clase</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }

        /// <summary>
        /// Metodo para hacer accesible la informacion del alumno
        /// </summary>
        /// <returns>string con la informacion del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion


        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
