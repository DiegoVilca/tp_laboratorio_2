using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;


namespace EntidadesAbstractas
{
    
    public abstract class Persona
    {

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;


        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion Enumerados


        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }

            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this.DNI = this.ValidarDni(this._nacionalidad, value); }
        }

        #endregion Propiedades


        #region Constructores
        //Constructor por defecto necesario para serializar xml
        protected Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        #endregion Constructores


        #region Metodos

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {



            if (dato >= 1 && dato <= 89999999)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");

            }
            else
            {
                if (dato >= 9000000)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }



        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoEntero = 0;

            
                if (!int.TryParse(dato, out datoEntero))
                {
                    throw new DniInvalidoException();
                }

                return this.ValidarDni(nacionalidad, datoEntero);
    
           
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    return "Cadena inválida";
                }
            }

            return dato;
        }

        #endregion Metodos

    }
}
