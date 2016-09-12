using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculadora
    {

        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            
            switch (validarOperador(operador))
            {
                case "+": resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                    
                case "-": resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                    
                case "*": resultado= numero1.getNumero() * numero2.getNumero();
                    break;
                    
                case "/":

                    if (numero2.getNumero() == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }

                    break;                  
            }

            return resultado;

        }



        public static string validarOperador(string operador)
        {
           
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                return "+";
            return operador;
            
        }
    }
}
