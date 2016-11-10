using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class ValorNumericoTest
    {

        /// <summary>
        /// Verifica que una cadena DNI incorrecta lance excepcion y que una correcto sea correctamente asignado al atributo DNI
        /// </summary>
        [TestMethod]
        public void DNICadenaAEnteroTest()
        {
            Alumno miAlumnoUno = new Alumno(1, "Rocio", "Perez", "33654222", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Yoga, Alumno.EEstadoCuenta.MesPrueba);

            //Comparo que el DNI cadena sea igual al DNI transformado a entero.
            Assert.AreEqual(miAlumnoUno.DNI, 33654222);


            //Verifico que una cadena invalida arroje excepcion.
            try
            {
                Alumno miAlumnoDos = new Alumno(1, "Rocio", "Perez", "336@4222", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Yoga, Alumno.EEstadoCuenta.MesPrueba);
            }
            catch (Exception ex)
            {

                Assert.IsInstanceOfType(ex, typeof(DniInvalidoException));
            }
        }


        [TestMethod]
        /// <summary>
        /// Comprueba que DNIs incorrectos segun nacionalidad lancen excepcion. 
        /// </summary>
        public void DNITest()
        {
            try
            {
                //Rango dni invalido para extranjero
                Alumno miAlumno = new Alumno(1, "Rocio", "Perez", "33654222", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Yoga, Alumno.EEstadoCuenta.MesPrueba);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NacionalidadInvalidaException));
            }

            try
            {
                //dni invalido para argentino
                Alumno miAlumno = new Alumno(1, "Rocio", "Perez", "0", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Yoga, Alumno.EEstadoCuenta.MesPrueba);

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NacionalidadInvalidaException));
            }

            try
            {
                //dni invalido para argentino
                Alumno miAlumno = new Alumno(1, "Rocio", "Perez", "95555555", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Yoga, Alumno.EEstadoCuenta.MesPrueba);

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NacionalidadInvalidaException));
            }
        }

        
    }
}
