using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Atributos
        private ETipo tipo;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion Propiedades

        #region Constructor
        /// <summary>
        /// Por defecto, ETipo será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Constructor Sedan que recibe también el valor del atributo tipo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion Constructor

        #region Metodo
        /// <summary>
        /// Sobrecarga del método Mostrar de la clase base, sumando los datos espeficicos
        /// de este tipo de vehiculo
        /// </summary>
        /// <returns>string con los datos del objeto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion Metodo

        /// <summary>
        /// Tipo anidado ETipo
        /// </summary>
        public enum ETipo 
        { 
            CuatroPuertas, 
            CincoPuertas 
        }
    }
}
