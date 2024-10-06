using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo__fianal_grafos_vuelos
{
    // Clase que representa un vuelo entre dos aeropuertos
    public class Vuelo
    {
        public int Destino { get; set; } // El aeropuerto de destino del vuelo
        public int Costo { get; set; }   // El costo del vuelo

        public Vuelo(int destino, int costo)
        {
            Destino = destino;
            Costo = costo;
        }
    }

    // Clase principal que implementa el algoritmo de Dijkstra para encontrar vuelos baratos
    public class GrafoVuelos
    {
        private Dictionary<int, List<Vuelo>> aeropuertos; // Diccionario que mapea aeropuertos con sus vuelos

        public GrafoVuelos()
        {
            aeropuertos = new Dictionary<int, List<Vuelo>>(); // Inicialización del diccionario
        }

        // Método que agrega un vuelo entre dos aeropuertos
        public void AgregarVuelo(int origen, int destino, int costo)
        {
            if (!aeropuertos.ContainsKey(origen))
            {
                aeropuertos[origen] = new List<Vuelo>(); // Si el aeropuerto no está en el diccionario, lo añade
            }
            aeropuertos[origen].Add(new Vuelo(destino, costo)); // Añade el vuelo al aeropuerto de origen
        }

        // Método que aplica el algoritmo de Dijkstra para encontrar la ruta más barata
        public void EncontrarVueloMasBarato(int origen, int destino)
        {
            // Diccionario que almacena el costo mínimo desde el origen hasta los demás aeropuertos
            Dictionary<int, int> distancias = new Dictionary<int, int>();

            // Diccionario para rastrear el aeropuerto anterior en la ruta óptima
            Dictionary<int, int> previo = new Dictionary<int, int>();

            // Inicialización de la cola de prioridad, ordenada por costo del vuelo
            SortedSet<(int costo, int aeropuerto)> colaPrioridad = new SortedSet<(int, int)>();

            // Inicialización de todas las distancias como "infinito"
            foreach (var aeropuerto in aeropuertos.Keys)
            {
                distancias[aeropuerto] = int.MaxValue;
            }

            distancias[origen] = 0; // La distancia al aeropuerto de origen es 0
            colaPrioridad.Add((0, origen)); // Añadir el origen a la cola de prioridad

            while (colaPrioridad.Count > 0)
            {
                var (costoActual, aeropuertoActual) = colaPrioridad.First(); // Obtener el aeropuerto con el menor costo
                colaPrioridad.Remove(colaPrioridad.First()); // Removerlo de la cola

                if (aeropuertoActual == destino) // Si llegamos al destino, terminamos
                {
                    Console.WriteLine($"El vuelo más barato tiene un costo de: {costoActual}");
                    ImprimirRuta(previo, destino); // Imprime la ruta desde el origen al destino
                    return;
                }

                // Revisar todos los vuelos desde el aeropuerto actual
                foreach (var vuelo in aeropuertos[aeropuertoActual])
                {
                    int costoNuevo = costoActual + vuelo.Costo;

                    // Si se encuentra un costo menor, se actualizan las distancias
                    if (costoNuevo < distancias[vuelo.Destino])
                    {
                        colaPrioridad.Remove((distancias[vuelo.Destino], vuelo.Destino)); // Remover el valor antiguo
                        distancias[vuelo.Destino] = costoNuevo; // Actualizar distancia
                        previo[vuelo.Destino] = aeropuertoActual; // Registrar el aeropuerto anterior
                        colaPrioridad.Add((costoNuevo, vuelo.Destino)); // Añadir el nuevo valor actualizado
                    }
                }
            }
        }

        // Método para imprimir la ruta óptima desde el origen hasta el destino
        private void ImprimirRuta(Dictionary<int, int> previo, int destino)
        {
            List<int> ruta = new List<int>();
            int actual = destino;

            while (previo.ContainsKey(actual))
            {
                ruta.Add(actual);
                actual = previo[actual]; // Volver al aeropuerto anterior en la ruta
            }

            ruta.Reverse(); // Revertir la lista para mostrar la ruta desde el origen
            Console.WriteLine("Ruta óptima: " + string.Join(" -> ", ruta));
        }
    }

}
