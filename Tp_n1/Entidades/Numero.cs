using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Setter de la propiedad numero.
        /// Valida que el valor a asignar sea distinto de 0.
        /// </summary>
        private string SetNumero
        {
            set 
            {
                if(this.ValidarNumero(value) != 0)
                {
                    this.numero = this.ValidarNumero(value);
                }
            }
        }
        /// <summary>
        /// Convierte un numero binario en decimal
        /// previa validacion de que el string sea un numero binario
        /// </summary>
        /// <param name="binario">recibe un string con el valor binario</param>
        /// <returns>string con el valor del numero ya convertido en decimal</returns>
        public string BinarioDecimal(string binario)
        {
            double numDecimal;

            if (this.EsBinario(binario))
            {
                numDecimal = (double)Convert.ToInt32(binario, 2);

                if (numDecimal > 0)
                {
                    return numDecimal.ToString();
                }
            }

            return "Valor invalido";
        }
        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">double decimal</param>
        /// <returns>string numero convertido en binario</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "";
            int numInt = (int)numero;

            if (numInt > 0)
            {
                while (numInt > 0)
                {
                    if (numInt % 2 == 0)
                    {
                        retorno += "0";
                    }
                    else
                    {
                        retorno += "1";
                    }

                    numInt /= 2;
                }
            }
            else
            {
                retorno = "0";
            }

            if (retorno == "0")
            {
                return "Valor inválido";
            }

            char[] charArray = retorno.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// Recibe un numero decimal en forma de string
        /// y lo convierte en binario
        /// </summary>
        /// <param name="numero">string con el valor del numero decimal a convertir</param>
        /// <returns>string con el valor binario del numero recibido</returns>
        public string DecimalBinario(string numero)
        {
            double auxNumero;

            if (double.TryParse(numero, out auxNumero))
            {
                return this.DecimalBinario(auxNumero);
            }

            return "Valor inválido";
        }
        /// <summary>
        /// Chequea que el string este compuesto por 1s y 0s
        /// </summary>
        /// <param name="binario">string con el numero binario</param>
        /// <returns>bool True en caso de ser decimal, caso contrario False</returns>
        private bool EsBinario(string binario)
        {
            foreach (char letra in binario)
            {
                if(letra != '0' && letra != '1')
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Constructor por defecto, primero en asignar valor
        /// inicializa en 0 el valor de numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe double
        /// </summary>
        /// <param name="numero">double con el valor del numero</param>
        public Numero(double numero):this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que recibe string
        /// </summary>
        /// <param name="strNumero">string con el valor del numero</param>
        public Numero(string strNumero)
        {
            this.numero = this.ValidarNumero(strNumero);
        }
        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double con el valor de la resta de ambos numeros</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double con el valor de la suma de ambos numeros</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double con el valor de la division de ambos numeros</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double con el valor de la multiplicacion de ambos numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Convierte el numero de string a double
        /// </summary>
        /// <param name="strNumero">numero en formato string</param>
        /// <returns>double con la conversion del string, caso contratio retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;

            if (double.TryParse(strNumero, out retorno))
            {
                return retorno;
            }

            return retorno = 0;
        }
    }
}
