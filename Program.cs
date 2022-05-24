// See https://aka.ms/new-console-template for more information
using System;



namespace tp06
{
    public enum cargos
    {
        Auxiliar = 0,
        Administrativo = 1,
        Ingeniero = 2,
        Especialista = 3,
        Investigador = 4
    }

    public class Program {
        public static void Main(string[] args)
        {
            
        }
    }

    public class Empleado {
        string nombre, apellido;
        DateTime fechaDeNacimiento, fechaDeIngreso;
        char estadoCivil, genero;
        double sueldoBasico;
        cargos cargo;

        
        
    }
}