using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Crea un archivo xml con la informacion que recibe
        /// </summary>
        /// <param name="archivo">Ruta destino del archivo a crear</param>
        /// <param name="datos">Datos que ser grabaran en el archivo</param>
        /// <returns>True si se logra crear el archivo</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                TextWriter tw = new StreamWriter(archivo);
                xs.Serialize(tw, datos);
                tw.Close();
                return true;
            }

            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }

        /// <summary>
        /// Lee la informacion de un archivo xml y la guarda en un
        /// tipo generico
        /// </summary>
        /// <param name="archivo">Ruta del archivo que se leera</param>
        /// <param name="datos">generic donde se guardara la informacion</param>
        /// <returns>True si se logra leer con exito</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                TextReader tr = new StreamReader(archivo);
                datos = (T)xs.Deserialize(tr);
                tr.Close();
                return true;
            }

            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }
    }
}
