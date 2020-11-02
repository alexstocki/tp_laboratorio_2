using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get 
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                return null;
            }
            set 
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }    
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Serializa la informacion de la universidad en un xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True si serializa con exito, False caso contrario</returns>
        public bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> auxXml = new Xml<Universidad>();
                string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
                return auxXml.Guardar(pathXml, uni);
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }

        /// <summary>
        /// Deserializa la informacion de un archivo xml y la guarda en un objeto tipo
        /// universidad
        /// </summary>
        /// <returns>Objeto tipo universidad</returns>
        public Universidad Leer()
        {
            try
            {
                Universidad uni = null;
                Xml<Universidad> auxXml = new Xml<Universidad>();
                string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
                auxXml.Leer(pathXml, out uni);
                return uni;
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }
        }

        /// <summary>
        /// Devuelve string con la informacion de la universidad recibida
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>string con la informacion de la universidad</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornada: ");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("*******************************\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si un alumno se encuentra en la lista de alumnos de la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno se encuentra en la lista de alumnos de la universidad, False caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                {
                    return true; 
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno no se encuentra en la lista de alumnos de la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si no se encuentra en la lista de alumnos de la universidad, False caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si el profesor esta en la lista de profesores de la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si un profesor no esta en la lista de profesores de la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Verifica si hay un profesor en la lista que de la clase 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Genera una nueva jornada y la agrega a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = new Profesor();
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    jornada.Alumnos.Add(a);
                }
            }

            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la lista de la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }
         /// <summary>
         /// Hace accesible la informacion de la universidad
         /// </summary>
         /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        public enum EClases
        {
            Programacion, 
            Laboratorio,
            Legislacion, 
            SPD
        }
    }
}
