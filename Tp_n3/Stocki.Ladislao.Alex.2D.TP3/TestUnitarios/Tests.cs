using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;
using Microsoft.Win32;
using System.Security;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Testea que se lance la excepcion tipo DniInvalidoException cuando
        /// se intenta crear un alumno con un formato de DNI erroneo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethodDniInvalidoException()
        {
            //Dni con formato invalido
            Alumno alumno = new Alumno(10, "Juan", "Alonso", "381818a8", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Testea que se lance la excepcion tipo AlumnoRepetidoException 
        /// cuando se intenta agregar al mismo alumno
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestMethodAlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Nicolas", "Calvo", "38181848", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            universidad += alumno;
            universidad += alumno;
        }

        /// <summary>
        /// Testea que se hayan instanciado las colecciones del objeto tipo Universidad
        /// </summary>
        [TestMethod]
        public void TestMethodColeccionInstanciada()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(universidad.Instructores);
        }
    }
}
