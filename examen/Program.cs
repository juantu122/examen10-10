using System;
using System.Linq;

namespace GestionAerolineas
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                MostrarMenu();
                opcion = int.Parse(Console.ReadLine() ?? "0");
                switch (opcion)
                {
                    case 1: CrearAvion(); break;
                    case 2: ListarAviones(); break;
                    case 3: BuscarAvionPorId(); break;
                    case 4: ModificarAvion(); break;
                    case 5: EliminarAvion(); break;
                    case 6: CrearAeropuerto(); break;
                    case 7: ListarAeropuertos(); break;
                    case 8: BuscarAeropuertoPorId(); break;
                    case 9: ModificarAeropuerto(); break;
                    case 10: EliminarAeropuerto(); break;
                    case 11: Console.WriteLine("Saliendo..."); break;
                    default: Console.WriteLine("Opción inválida"); break;
                }
                
            } while (opcion != 11);
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Crear Avión");
            Console.WriteLine("2. Listar Aviones");
            Console.WriteLine("3. Buscar Avión por ID");
            Console.WriteLine("4. Modificar Avión");
            Console.WriteLine("5. Eliminar Avión");
            Console.WriteLine("6. Crear Aeropuerto");
            Console.WriteLine("7. Listar Aeropuertos");
            Console.WriteLine("8. Buscar Aeropuerto por ID");
            Console.WriteLine("9. Modificar Aeropuerto");
            Console.WriteLine("10. Eliminar Aeropuerto");
            Console.WriteLine("11. Salir");
            Console.Write("Selecciona una opción: ");
        }

       

        private static void ListarAviones()
        {
            Console.Clear();
            Console.WriteLine("\nLista de Aviones:");
            BaseDatos.Aviones.ForEach(a => Console.WriteLine(a.Detalle()));
        }

        private static void BuscarAvionPorId()
        {
            Console.Clear();
            Console.Write("ID a buscar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var avion = BaseDatos.Aviones.FirstOrDefault(a => a.Id == id);
            Console.WriteLine(avion != null ? avion.Detalle() : "No encontrado.");
        }

        private static void ModificarAvion()
        {
            Console.Clear();
            Console.Write("ID del avión a modificar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var avion = BaseDatos.Aviones.FirstOrDefault(a => a.Id == id);
            if (avion == null)
            {
                Console.WriteLine("No encontrado.");
                return;
            }

            Console.Write("Nuevo Modelo: ");
            avion.Modelo = Console.ReadLine() ?? "";
            Console.Write("Nueva Capacidad Pasajeros: ");
            avion.CapacidadPasajeros = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nuevo Año Fabricación: ");
            avion.AnoFabricacion = int.Parse(Console.ReadLine() ?? "0");

            BaseDatos.GuardarAviones();
            Console.WriteLine("Modificado.");
        }

        private static void EliminarAvion()
        {
            Console.Clear();
            Console.Write("ID del avión a eliminar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            if (BaseDatos.Aviones.RemoveAll(a => a.Id == id) > 0)
            {
                BaseDatos.GuardarAviones();
                Console.WriteLine("Eliminado.");
            }
            else
            {
                Console.WriteLine("No encontrado.");
            }
        }

        

        private static void ListarAeropuertos()
        {
            Console.Clear();
            Console.WriteLine("\nLista de Aeropuertos:");
            BaseDatos.Aeropuertos.ForEach(ap => Console.WriteLine(ap.Detalle()));
        }

        private static void BuscarAeropuertoPorId()
        {
            Console.Clear();
            Console.Write("ID a buscar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var ap = BaseDatos.Aeropuertos.FirstOrDefault(a => a.Id == id);
            Console.WriteLine(ap != null ? ap.Detalle() : "No encontrado.");
        }

        private static void ModificarAeropuerto()
        {
            Console.Clear();
            Console.Write("ID del aeropuerto a modificar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var ap = BaseDatos.Aeropuertos.FirstOrDefault(a => a.Id == id);
            if (ap == null)
            {
                Console.WriteLine("No encontrado.");
                return;
            }

            Console.Write("Nuevo Aeropuerto: ");
            ap.Nombre = Console.ReadLine() ?? "";
            Console.Write("Nueva Ubicación: ");
            ap.Ubicacion = Console.ReadLine() ?? "";
            Console.Write("Nuevo Número Pistas: ");
            ap.NumeroPistas = int.Parse(Console.ReadLine() ?? "0");

            BaseDatos.GuardarAeropuertos();
            Console.WriteLine("Modificado.");
        }


        private static void CrearAvion()
        {
            Console.Clear();
            int id = BaseDatos.GetNextAvionId();
            Console.WriteLine($"Asignado ID de Avión: {id}");
            Console.Write("Modelo: ");
            string mod = Console.ReadLine() ?? "";
            Console.Write("Capacidad Pasajeros: ");
            int cap = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Año Fabricación: ");
            int ano = int.Parse(Console.ReadLine() ?? "0");

            BaseDatos.Aviones.Add(new Avion(id, mod, cap, ano));
            BaseDatos.GuardarAviones();
            Console.WriteLine("Avión creado.");
        }

        private static void CrearAeropuerto()
        {
            Console.Clear();
            int id = BaseDatos.GetNextAeropuertoId();
            Console.WriteLine($"Asignado ID de Aeropuerto: {id}");
            Console.Write("Aeropuerto: ");
            string nom = Console.ReadLine() ?? "";
            Console.Write("Ubicación: ");
            string ubi = Console.ReadLine() ?? "";
            Console.Write("Número Pistas: ");
            int pistas = int.Parse(Console.ReadLine() ?? "0");

            BaseDatos.Aeropuertos.Add(new Aeropuerto(id, nom, ubi, pistas));
            BaseDatos.GuardarAeropuertos();
            Console.WriteLine("Aeropuerto creado.");
        }

        private static void EliminarAeropuerto()
        {
            Console.Clear();
            Console.Write("ID del aeropuerto a eliminar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            if (BaseDatos.Aeropuertos.RemoveAll(a => a.Id == id) > 0)
            {
                BaseDatos.GuardarAeropuertos();
                Console.WriteLine("Eliminado.");
            }
            else
            {
                Console.WriteLine("No encontrado.");
            }

           
        }
    }
}
