using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Atributos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get;}
        #endregion Propiedades

        #region Constructor
        /// <summary>
        /// Constructor utilizado por las clases que heredan de Vehiculo
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion Constructor

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion Metodos

        #region Operadores
        /// <summary>
        /// Retorna todos los datos del veichulo
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendLine($"MARCA : {p.marca.ToString()}\r\n");
            sb.AppendLine($"COLOR : {p.color.ToString()}\r\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion Operadores

        /// <summary>
        /// Tipo anidado EMarca
        /// </summary>
        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault, 
            Toyota, 
            BMW, 
            Honda, 
            HarleyDavidson
        }

        /// <summary>
        /// Tipo anidado ETamanio
        /// </summary>
        public enum ETamanio
        {
            Chico, 
            Mediano, 
            Grande
        }
    }
}
