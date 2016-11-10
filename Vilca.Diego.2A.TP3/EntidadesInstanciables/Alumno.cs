using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    
   
    public sealed class Alumno : PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;


        #region Enumerados

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            MesPrueba
        }

        #endregion Enumerados


        #region Constructores
        //Constructor por defecto necesario para serializar xml
        private Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion Constructores


        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("");
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion Metodos


        #region Sobrecargas

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
            {
                return true;
            }

            return false;
        }

        #endregion Sobrecargas

    }
}
