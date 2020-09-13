using System;
using System.Net.Http.Headers;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;

            switch (ValidarOperador(operador))
            {
                case "+":
                    {
                        resultado = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        resultado = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        resultado = num1 * num2;
                        break;
                    }
                default:
                    {
                        resultado = num1 / num2;
                        break;
                    }
            }

            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            string retorno;

            if (operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }

            return retorno;
        }
    }
}
