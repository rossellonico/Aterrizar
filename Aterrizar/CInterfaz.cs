using System;
namespace Aterrizar
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*        Sistema de Gestión de Vuelos         *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[E] Establecer impuesto.");
            Console.WriteLine("\n[C] Conocer impuesto.");
            Console.WriteLine("\n[A] Agregar un vuelo.");
            Console.WriteLine("\n[M] Mostrar datos de un vuelo.");
            Console.WriteLine("\n[L] Listar los datos de todos los vuelos.");
            Console.WriteLine("\n[R] Remover un vuelo.");
            Console.WriteLine("\n[T] Remover todos los vuelos.");
            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();
            //.Trim() Remueve espacios en blanco previos y posteriores.

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

