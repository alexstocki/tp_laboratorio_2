using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        private int legajo;
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica si la instancia de clase Universitario es igual al parametro
        /// object recibido 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si son iguales caso contrario False</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                if (((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Devuelve los datos del universitario
        /// </summary>
        /// <returns>string con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder universitario = new StringBuilder();
            universitario.AppendLine(base.ToString());
            universitario.AppendFormat("Legajo: {0}", this.legajo);
            return universitario.ToString();
        }

        /// <summary>
        /// Verifica si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son iguales, caso contrario False</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Verifica si dos universitarios son distintos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son distintos, caso contrario False</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
    }
}
