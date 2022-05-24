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
                    Console.WriteLine("\n1. Sumar\n2. Restar\n3. Multiplicar\n4. Dividir\n5. Limpiar Resultado");
                    seguir = Convert.ToInt32(Console.ReadLine());
                } while (seguir<=0 || seguir>=6);

                if (seguir!=5)
                {
                    if (bandera==0)
                    {
            
                        Console.Write("\nIngresar el PRIMER numero: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nIngresar el SEGUNDO numero: ");
                        num2 = Convert.ToInt32(Console.ReadLine());

                        switch (seguir)
                        {
                            case 1: CALCULANDO.Sumar(num1,num2);break;
                            case 2: CALCULANDO.Restar(num1,num2);break;
                            case 3: CALCULANDO.Multiplicar(num1,num2);break;
                            case 4: CALCULANDO.Dividir(num1,num2);break;
                            default:
                            break;
                        }
                    }
                    else
                    {
                        Console.Write("\nIngresar el numero para operar con el RESULTADO anterior: ");
                        num2 = Convert.ToInt32(Console.ReadLine());
                        switch (seguir)
                        {
                            case 1: CALCULANDO.Sumar(num2);break;
                            case 2: CALCULANDO.Restar(num2);break;
                            case 3: CALCULANDO.Multiplicar(num2);break;
                            case 4: CALCULANDO.Dividir(num2);break;
                            default:
                            break;
                        }
                    }
                }else
                {
                    CALCULANDO.Limpiar();
                    bandera=-1;    //para que vuelva a preguntar por los dos numeros, asi no haga una operacion con el resultado en 0 y un numero
                }
                

                Console.WriteLine("\n\nDesea seguir realizando operaciones? 0 = SI");
                seguir = Convert.ToInt32(Console.ReadLine());
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
            Console.Write($"\nLa SUMA entre {Num1} y de {Num2} es igual a: {resultado}");
        }
        public void Sumar(double Num2){
            Console.Write($"\nLa SUMA entre {resultado} y de {Num2} es igual a: ");
            resultado += Num2;
            Console.Write(resultado);
        }

        public void Restar(double Num1, double Num2){
            resultado = Num1-Num2;
            Console.Write($"\nLa RESTA entre {Num1} y de {Num2} es igual a: {resultado}");

        }
        public void Restar(double Num2){
            Console.Write($"\nLa RESTA entre {resultado} y de {Num2} es igual a: ");
            resultado -= Num2;
            Console.Write(resultado);
        }

        public void Multiplicar(double Num1, double Num2){
            resultado = Num1*Num2;
            Console.Write($"\nLa MULTIPLACION entre {Num1} y {Num2} es igual a: {resultado}");
        }
        public void Multiplicar(double Num2){
            Console.Write($"\nLa MULTIPLACION entre {resultado} y de {Num2} es igual a: ");
            resultado *= Num2;
            Console.Write(resultado);
        }

        public void Dividir(double Num1, double Num2){
            resultado = Num1/Num2;
            Console.Write($"\nLa DIVISION de {Num1} en {Num2} es igual a: {resultado}");
        }
        public void Dividir(double Num2){
            Console.Write($"\nLa DIVISION de {resultado} en {Num2} es igual a: ");
            resultado /= Num2;
            Console.Write(resultado);
        }

        public void Limpiar(){
            resultado = 0;
        }
    }
}