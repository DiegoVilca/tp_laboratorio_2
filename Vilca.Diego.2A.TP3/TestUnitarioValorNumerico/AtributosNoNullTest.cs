using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitario
{
    [TestClass]
    public class AtributosNoNullTest
    {
        [TestMethod]
        public void AtributosNoNullInstructorTest()
        {
            Instructor miInstructor = new Instructor(1, "Jose", "Sanchez", "42123456", Persona.ENacionalidad.Argentino);

            //Verifico que los atributos del alumno no sean null
            Assert.IsNotNull(miInstructor.Apellido);
            Assert.IsNotNull(miInstructor.Nombre);
            Assert.IsNotNull(miInstructor.DNI);
            Assert.IsNotNull(miInstructor.Nacionalidad);
        }

        [TestMethod]
        public void AtributosNoNullAlumnoTest()
        {
            Alumno miAlumno = new Alumno(1, "Rocio", "Perez", "33654222", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Yoga, Alumno.EEstadoCuenta.MesPrueba);

            //Verifico que los atributos del alumno no sean null
            Assert.IsNotNull(miAlumno.Apellido);
            Assert.IsNotNull(miAlumno.Nombre);
            Assert.IsNotNull(miAlumno.DNI);
            Assert.IsNotNull(miAlumno.Nacionalidad);
            
        }

        [TestMethod]
        public void AtributosNoNullJornadaTest()
        { 
            Instructor miInstructor = new Instructor(1, "Jose", "Sanchez", "42123456", Persona.ENacionalidad.Argentino);

            Jornada miJornada = new Jornada(Gimnasio.EClases.Pilates, miInstructor);

            //Verifico que la jornada no sea null
            Assert.IsNotNull(miJornada.ToString());
        }

        [TestMethod]
        public void AtributosNoNullGimnasioTest()
        {

            Gimnasio miGimnasio = new Gimnasio();

            //Verifico que el gimnasio no sea null
            Assert.IsNotNull(miGimnasio.ToString());
            
        }

    }
}
