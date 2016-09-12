using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Numero
    {
        private double numero;


        //Constructores

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            setNumero(numero);
        }


        //Getter
        public double getNumero()
        {
            return this.numero;
        }
        //Setter
        private void setNumero(string numero)
        {
           this.numero = validarNumero(numero);
        }

        
        /// <summary>
        /// Valida que el numero ingresado sea valido.
        /// De lo contrario devuelve cero.
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private static double validarNumero(string numeroString)
        {
            double numero;
            bool esValido = double.TryParse(numeroString, out numero);

            if (esValido)
                return numero;
            return 0;

        }


        //Sobrecarga de operadores

        public static double operator +(Numero numero1, Numero numero2)
        {
            return (numero1.numero + numero2.numero);
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            return (numero1.numero - numero2.numero);
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            return (numero1.numero * numero2.numero);
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            return (numero1.numero / numero2.numero);
        }

        public static bool operator ==(Numero numero1, int numero2)
        {
            return numero1.numero == numero2;
        }

        public static bool operator !=(Numero numero1, int numero2)
        {
            return !(numero1.numero == numero2);
        }

    }
}
