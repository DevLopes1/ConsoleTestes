using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestes.Programas
{
    public static class CalcOperadoresBasicos
    {
        public static void menuPrograma()
        {
            Console.Write("Bem Vindo a Calc Operadores básicos...\nComeçe digitando o operador\n=>");
            string operador = Console.ReadLine();

            Console.WriteLine("Valor digitado: " + operador);

            Console.Write("Digite o primeiro valor\n=>");
            string valor1 = Console.ReadLine();

            string valor2 = "";
            if (operador == "/")
            {
                Console.Write("Agora digite o divisor\n=>");
                valor2 = Console.ReadLine();
            }
            else
            {
                Console.Write("Agora digite o segundo valor\n=>");
                valor2 = Console.ReadLine();
            }
            

            double v1;
            double v2;
             double.TryParse(valor1, out v1);
             double.TryParse(valor2, out v2);

            char oprt = operador[0];
            double result = calc(oprt, v1, v2);
            Console.Write("Resultado: " + result.ToString());
        }
        public static double calc(char operador, double valor1, double valor2)
        {
            //+ - / *
            double valorRet = 0;
            switch (operador)
            {
                case '+':
                    valorRet = valor1 + valor2;
                    break;
                case '-':
                    valorRet = valor1 - valor2;
                    break;
                case '/':
                    if(valor2 <= 0)
                    {
                        Console.WriteLine("=>#ERROR#=> Não é possível dividir por zero.");
                        break;
                    }
                    valorRet = valor1 / valor2;
                    break;
                case '*':
                    valorRet = valor1 * valor2;
                    break;
                default:
                    valorRet = 0;
                    break;
            }

            return valorRet;
        }
    }
}
