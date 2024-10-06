using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo__fianal_grafos_vuelos
{
    // Clase principal donde se definen los aeropuertos y se ejecuta el programa
    public class Programa
    {
        public static void Main(string[] args)
        {
            // Crear una instancia del grafo de vuelos
            GrafoVuelos grafo = new GrafoVuelos();

            // Agregar vuelos de aerolíneas conocidas (Ejemplos: American Airlines, Delta, Emirates)
            grafo.AgregarVuelo(0, 1, 200); // American Airlines: De Nueva York (0) a Los Ángeles (1) por $200
            grafo.AgregarVuelo(0, 2, 300); // Delta: De Nueva York (0) a Miami (2) por $300
            grafo.AgregarVuelo(1, 2, 100); // Southwest: De Los Ángeles (1) a Miami (2) por $100
            grafo.AgregarVuelo(1, 3, 400); // Emirates: De Los Ángeles (1) a Dubái (3) por $400
            grafo.AgregarVuelo(2, 3, 200); // Qatar Airways: De Miami (2) a Dubái (3) por $200
            grafo.AgregarVuelo(3, 4, 500); // Lufthansa: De Dubái (3) a Frankfurt (4) por $500
            grafo.AgregarVuelo(2, 4, 700); // United Airlines: De Miami (2) a Frankfurt (4) por $700

            // Solicitar al usuario el aeropuerto de origen y destino
            Console.WriteLine("Ingrese el aeropuerto de origen (0 = Nueva York, 1 = Los Ángeles, 2 = Miami, 3 = Dubái, 4 = Frankfurt):");
            int origen = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el aeropuerto de destino (0 = Nueva York, 1 = Los Ángeles, 2 = Miami, 3 = Dubái, 4 = Frankfurt):");
            int destino = int.Parse(Console.ReadLine());

            // Encontrar y mostrar el vuelo más barato
            grafo.EncontrarVueloMasBarato(origen, destino);
            Console.Read();
        }
    }
}
