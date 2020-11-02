using System;
using System.Collections.Generic;
using System.Text;
using Clases_Abstractas;
using System.Threading;
using System.Text.RegularExpressions;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Métodos
        /// <summary>
        /// Asigna dos clases random al profesor
        /// </summary>
        private void _randonClase()
        {
            int randomNumber;

            for (int i = 0; i < 2; i++)
            {
                System.Threading.Thread.Sleep(1000);
                randomNumber = random.Next(0, 4);
                switch (randomNumber)
                {
                    case 0:
                        {
                            this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                            break;
                        }
                    case 1:
                        {
                            this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                            break;
                        }
                    case 2:
                        {
                            this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                            break;
                        }
                    default:
                        {
                            this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Devuelve string con los datos del profesor
        /// </summary>
        /// <returns>string con la informacion del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder profesor = new StringBuilder();
            profesor.AppendLine(base.MostrarDatos());
            profesor.AppendLine(this.ParticiparEnClase());
            return profesor.ToString();
        }

        /// <summary>
        /// Verifica si un profesor da una clase determinada
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns>True si da la clase, False caso contrario</returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in profesor.clasesDelDia)
            {
                if (c == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un profesor no da una clase determinada
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns>True si no da la clase, False caso contrario</returns>
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
        }

        /// <summary>
        /// Devuelve string con las clases que da el profesor
        /// </summary>
        /// <returns>string con las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendFormat("{0}", clase.ToString());
            }
            return sb.ToString();
        }

        public Profesor()
        {

        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randonClase();
        }

        /// <summary>
        /// Hace accesible la informacion del profesor 
        /// </summary>
        /// <returns>string con la informacion del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
