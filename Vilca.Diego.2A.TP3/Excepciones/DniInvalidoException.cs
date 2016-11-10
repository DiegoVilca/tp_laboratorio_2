using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;


        #region Constructores

        public DniInvalidoException()
            : base()
        {
            Console.WriteLine("La nacionalidad no se condice con el numero de DNI");
        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
            this.mensajeBase = message;
        }

        public DniInvalidoException(Exception e)
            : this(null, e)
        {

        }

        public DniInvalidoException(string message)
            : this(message, null)
        {

        }



        #endregion Constructores
    }
}
