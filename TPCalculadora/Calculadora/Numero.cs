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

        //Metodo

        private static double validarNumero(string numeroString)
        {
            double numero;
            bool esValido = double.TryParse(numeroString, out numero);

            if (esValido)
                return numero;
            return 0;


        }


    }
}
