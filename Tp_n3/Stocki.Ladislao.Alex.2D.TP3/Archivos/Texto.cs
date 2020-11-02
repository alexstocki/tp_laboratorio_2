using System;
using System.IO;
using System.Threading;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Crea un archivo ext con la informacion que recibe como parametro
        /// </summary>
        /// <param name="archivo">Ruta destino del archivo</param>
        /// <param name="datos">Datos que se grabaran en el archivo</param>
        /// <returns>True si se guarda el archivo</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.WriteLine(datos);
                sw.Close();
                return true;
            }

            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }

        /// <summary>
        /// Lee la informacion de un archivo txt y la almacena en un string
        /// </summary>
        /// <param name="archivo">Ruta del archivo que se leera</param>
        /// <param name="datos">String donde se guardara la informacion leida</param>
        /// <returns>True si se logra leer informacion del archivo</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }

            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }
    }
}
