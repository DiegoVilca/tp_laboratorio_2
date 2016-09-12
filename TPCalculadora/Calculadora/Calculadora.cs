using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculadora
    {
        /// <summary>
        /// Metodo que realiza la operacion numerica.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {

            double resultado = 0;


            # region Switch que usa sobrecargas

            switch (validarOperador(operador))
            {
                case "+": resultado = numero1 + numero2;
                    break;

                case "-": resultado = numero1 - numero2;
                    break;

                case "*": resultado = numero1 * numero2;
                    break;

                case "/":

                    if (numero2 == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numero1 / numero2;
                    }

                    break;
            }

            # endregion 

            #region Switch que no usa sobrecargas

            //switch (validarOperador(operador))
            //{
            //    case "+": resultado = numero1.getNumero() + numero2.getNumero();
            //        break;

            //    case "-": resultado = numero1.getNumero() - numero2.getNumero();
            //        break;

            //    case "*": resultado = numero1.getNumero() * numero2.getNumero();
            //        break;

            //    case "/":

            //        if (numero2.getNumero() == 0)
            //        {
            //            resultado = 0;
            //        }
            //        else
            //        {
            //            resultado = numero1.getNumero() / numero2.getNumero();
            //        }

            //        break;
            //}

            #endregion 

            

            return resultado;

        }


        /// <summary>
        /// Valida que el operador ingresado en el comboBox sea valido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
           
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                return "+";
            return operador;
            
        }
    }
}
