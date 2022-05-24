// See https://aka.ms/new-console-template for more information
using System;

namespace tp06
{
    public class Program {
        public static void Main(string[] args)
        {
            Calculadora CALCULANDO = new Calculadora();
            int seguir = 0,bandera = 0, num1, num2;

            do
            {
                do
                {
                    Console.WriteLine("1. Sumar\n2. Restar\n3. Multiplicar\n4. Dividir\n5. Limpiar Resultado");
                    seguir = Convert.ToInt32(Console.Read());
                } while (seguir<=0 || seguir>=6);

                if (bandera==0)
                {
                    Console.Write("\nIngresar el PRIMER numero: ");
                    num1 = Console.Read();
                    Console.Write("\nIngresar el SEGUNDO numero: ");
                    num2 = Console.Read();

                    switch (seguir)
                    {
                        case 1: CALCULANDO.Sumar(num1,num2);break;
                        case 2: CALCULANDO.Restar(num1,num2);break;
                        case 3: CALCULANDO.Multiplicar(num1,num2);break;
                        case 4: CALCULANDO.Dividir(num1,num2);break;
                        case 5: CALCULANDO.Limpiar();bandera=-1;break;
                        default:
                        break;
                    }
                }
                else
                {
                    Console.Write("\nIngresar el numero para operar con el RESULTADO anterior: ");
                    num2 = Console.Read();
                    switch (seguir)
                    {
                        case 1: CALCULANDO.Sumar(num2);break;
                        case 2: CALCULANDO.Restar(num2);break;
                        case 3: CALCULANDO.Multiplicar(num2);break;
                        case 4: CALCULANDO.Dividir(num2);break;
                        case 5: CALCULANDO.Limpiar();bandera=-1;break;
                        default:
                        break;
                    }
                }

                Console.WriteLine("Desea seguir realizando operaciones? 1 = SI");
                seguir = Console.Read();
                bandera++;
            } while (seguir==0);
        }
    }

    public class Calculadora{
        private double resultado;
        
        public Calculadora(){
            resultado = 0;
        }

        public void Sumar(double Num1, double Num2){
            resultado = Num1+Num2;
            Console.WriteLine("Resultado = " + resultado);
        }
        public void Sumar(double Num2){
            resultado += Num2;
            Console.WriteLine("Resultado = " + resultado);
        }

        public void Restar(double Num1, double Num2){
            resultado = Num1-Num2;
            Console.WriteLine("Resultado = " + resultado);
        }
        public void Restar(double Num2){
            resultado -= Num2;
            Console.WriteLine("Resultado = " + resultado);
        }

        public void Multiplicar(double Num1, double Num2){
            resultado = Num1*Num2;
            Console.WriteLine("Resultado = " + resultado);
        }
        public void Multiplicar(double Num2){
            resultado *= Num2;
            Console.WriteLine("Resultado = " + resultado);
        }

        public void Dividir(double Num1, double Num2){
            resultado = Num1/Num2;
            Console.WriteLine("Resultado = " + resultado);
        }
        public void Dividir(double Num2){
            resultado /= Num2;
            Console.WriteLine("Resultado = " + resultado);
        }

        public void Limpiar(){
            resultado = 0;
        }
    }
}