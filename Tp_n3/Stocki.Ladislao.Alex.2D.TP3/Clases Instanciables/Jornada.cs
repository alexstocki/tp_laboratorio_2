using System;
using System.Collections.Generic;
using System.Text;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        
        public EClases Clase { get { return this.clase; } set { this.clase = value; } }

        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }
        #endregion

        #region Métodos
        /// <summary>
        /// Crea un archivo txt con la informacion de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si se guarda el archivo, False caso contrario</returns>
        public bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                string pathTxt = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
                return txt.Guardar(pathTxt, jornada.ToString());
            }

            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Lee un archivo txt, guarda la informacion en un string
        /// </summary>
        /// <returns>string con la informacion leida en al archivo txt</returns>
        public string Leer()
        {
            string informacion = string.Empty;
            try
            {
                Texto txt = new Texto();
                string pathTxt = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "Jornada.txt";
                txt.Leer(pathTxt, out informacion);
                return informacion;
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }
        }

        /// <summary>
        /// Verifica si un alumno forma parte de una jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns>True si el alumno forma parte de la jornada, False caso contrario</returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            foreach (Alumno a in jornada.Alumnos)
            {
                if (a == alumno)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno no forma parte de una jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns>True si el alumno no forma parte de la jornada, False caso contrario</returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        /// <summary>
        /// Se agrega a un alumno a la lista de alumnos de la jornada siempre
        /// y cuando este no forme parte de ella
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns>Jornada con el alumno agregado en caso de exito</returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno)
            {
                jornada.Alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return jornada;
        }

        /// <summary>
        /// Hace accesible la informacion de la jornada
        /// </summary>
        /// <returns>string con la informacion de la joranada</returns>
        public override string ToString()
        {
            StringBuilder jornada = new StringBuilder();
            jornada.AppendFormat("CLASE: {0}\tPROFESOR: {1}\tALUMNOS: ", this.Clase, this.Instructor);
            foreach (Alumno alumno in this.Alumnos)
            {
                jornada.AppendLine(alumno.ToString());
            }
            return jornada.ToString();
        }
        #endregion
    }
}
