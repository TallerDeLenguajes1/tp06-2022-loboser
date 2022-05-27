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
            /*
            
            string nombre = "Sergio", apellido = "Lobo";
            DateTime fechaDeNacimiento = new DateTime(2001, 5, 11), fechaDeIngreso = new DateTime(2018, 3, 2);
            char estadoCivil = 'C', genero = 'M';
            double sueldoBasico = 65000;
            cargos cargo = cargos.Ingeniero;
            
            */

            Empleado Empleado1 = CargarEmpleado();
            Empleado Empleado2 = CargarEmpleado();
            Empleado Empleado3 = CargarEmpleado();
            
            MostrarEmpleado(Empleado1);
            MostrarEmpleado(Empleado2);
            MostrarEmpleado(Empleado3);

            Console.WriteLine("\n\nMonto Total: " + (Empleado1.Salario+Empleado2.Salario+Empleado3.Salario));

            Empleado EmpleadoProximoAJubilarse;
            if (Empleado1.ParaJubilarse<=Empleado2.ParaJubilarse && Empleado1.ParaJubilarse<=Empleado3.ParaJubilarse)
            {
                EmpleadoProximoAJubilarse = Empleado1;
            }else if (Empleado2.ParaJubilarse<=Empleado1.ParaJubilarse && Empleado2.ParaJubilarse<=Empleado3.ParaJubilarse)
            {
                EmpleadoProximoAJubilarse = Empleado2;
            }else
            {
                EmpleadoProximoAJubilarse = Empleado3;
            }

            Console.WriteLine("Empleado Proximo a Jubilarse: ");
            MostrarEmpleado(EmpleadoProximoAJubilarse);
            
        }

        public static Empleado CargarEmpleado(){
            Console.Write("\n\nNombre del Empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido del Empleado: ");
            string apellido = Console.ReadLine();

            int anio, mes, dia;

            Console.WriteLine("\nFecha de Nacimiento");
            Console.Write("Anio: ");
            anio = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Mes: ");
                mes = Convert.ToInt32(Console.ReadLine());
            } while (mes<1 || mes>12);
            do
            {
                Console.Write("Dia: ");
                dia = Convert.ToInt32(Console.ReadLine());
            } while (dia<1 || dia>31);
            var fechaDeNacimiento = new DateTime(anio, mes, dia);

            Console.WriteLine("\nFecha de Ingreso a la Empresa");
            Console.Write("Anio: ");
            anio = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Mes: ");
                mes = Convert.ToInt32(Console.ReadLine());
            } while (mes<1 || mes>12);
            do
            {
                Console.Write("Dia: ");
                dia = Convert.ToInt32(Console.ReadLine());
            } while (dia<1 || dia>31);
            var fechaDeIngreso = new DateTime(anio, mes, dia);

            char estadoCivil;
            Console.Write("\nEtado Civil (1 = Soltero / Cualquier otro Numero = Casado): ");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                estadoCivil = 'S';
                
            }else
            {
                estadoCivil = 'C';
            }


            char genero;
            Console.Write("\nGenero (1 = Femenino / Cualquier otro Numero = Masculino): ");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                genero = 'F';
                
            }else
            {
                genero = 'M';
            }

            Console.Write("\nSueldo Basico: ");
            double sueldoBasico = Convert.ToDouble(Console.ReadLine());

            cargos cargo = cargos.Auxiliar;
            Console.WriteLine("\nCargo: 0 = Auxiliar / 1 = Administrativo / 2 = Ingeniero / 3 = Especialista / 4 = Investigador");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    cargo = cargos.Auxiliar;
                    break;
                case 1:
                    cargo = cargos.Administrativo;
                    break;
                case 2:
                    cargo = cargos.Ingeniero;
                    break;
                case 3:
                    cargo = cargos.Especialista;
                    break;
                case 4:
                    cargo = cargos.Investigador;
                    break;
                default:
                    break;
            }

            Empleado aux = new Empleado(nombre, apellido, fechaDeNacimiento, fechaDeIngreso, estadoCivil, genero, sueldoBasico, cargo);

            return aux;
        }
        public static void MostrarEmpleado(Empleado Empleado){
            Console.WriteLine("Empleado: " + Empleado.Nombre + " " + Empleado.Apellido);
            Console.WriteLine("Antiguedad: " + Empleado.Antiguedad);
            Console.WriteLine("Edad: " + Empleado.Edad);
            Console.WriteLine("Le Falta " + Empleado.ParaJubilarse + " anios para jubilarse");
            Console.WriteLine("Su Salario es: " + Empleado.Salario + "\n\n");
        }
    }

    public class Empleado {
        string nombre, apellido;
        DateTime fechaDeNacimiento, fechaDeIngreso;
        char estadoCivil, genero;
        double sueldoBasico;
        cargos cargo;
        public string Nombre{
            get { return nombre; }
        }
        public string Apellido{
            get { return apellido; }
        }
        public int Antiguedad{
            get { return DateTime.Today.AddTicks(-fechaDeIngreso.Ticks).Year - 1; }
        }
        public int Edad{
            get { return DateTime.Today.AddTicks(-fechaDeNacimiento.Ticks).Year - 1; }
        }
        public int ParaJubilarse{
            get { 
                if (genero == 'M')
                {
                    return 65 - Edad;
                }else
                {
                    return 60 - Edad;
                }
            }
        }

        public double Salario{
            get {
                double adicional;

                if (Antiguedad<20)
                {
                    adicional = sueldoBasico*(0.01*Antiguedad);
                }else
                {
                    adicional = sueldoBasico*(0.25);
                }

                if (cargo == cargos.Ingeniero || cargo == cargos.Especialista)
                {
                    adicional += adicional*0.5;
                }

                if (estadoCivil == 'C')
                {
                     adicional += 15000;
                }

                return sueldoBasico+adicional;
            }
        }

        public Empleado(string Nombre, string Apellido, DateTime FechaDeNacimiento, DateTime FechaDeIngreso, char EstadoCivil, char Genero, double SueldoBasico, cargos Cargo){
            nombre = Nombre;
            apellido = Apellido;
            fechaDeNacimiento = FechaDeNacimiento;
            fechaDeIngreso = FechaDeIngreso;
            estadoCivil = EstadoCivil;
            genero = Genero;
            sueldoBasico = SueldoBasico;
            cargo = Cargo;
        }
    }
}