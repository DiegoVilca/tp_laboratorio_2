using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace EntidadesAbstractas
{


    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;


        #region Constructor
        //Constructor por defecto necesario para serializar xml
        protected PersonaGimnasio()
        {

        }
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        #endregion Constructor


        #region Metodos

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("CARNET NUMERO: " + this._identificador.ToString());


            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();


        public override bool Equals(object obj)
        {
            if (this == (PersonaGimnasio)obj)
            {
                return true;
            }

            return false;
        }

        #endregion Metodos


        #region Sobrecargas

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.GetType() == pg2.GetType())
            {
                if (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion Sobrecargas


    }
}
