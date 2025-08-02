using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GestionAerolineas
{
    public static class BaseDatos
    {
        private const string FILE_AVIONES = "aviones.txt";
        private const string FILE_AEROPUERTOS = "aeropuertos.txt";

        public static List<Avion> Aviones { get; private set; } = new List<Avion>();
        public static List<Aeropuerto> Aeropuertos { get; private set; } = new List<Aeropuerto>();

        static BaseDatos()
        {
            CargarAviones();
            CargarAeropuertos();
        }

        public static int GetNextAvionId()
        {
            return Aviones.Any()
                ? Aviones.Max(a => a.Id) + 1
                : 1;
        }

        public static int GetNextAeropuertoId()
        {
            return Aeropuertos.Any()
                ? Aeropuertos.Max(a => a.Id) + 1
                : 1;
        }

        public static void CargarAviones()
        {
            Aviones.Clear();
            if (!File.Exists(FILE_AVIONES)) return;

            foreach (var linea in File.ReadAllLines(FILE_AVIONES))
            {
                var partes = linea.Split(',');
                var a = new Avion(
                    int.Parse(partes[0]),
                    partes[1],
                    int.Parse(partes[2]),
                    int.Parse(partes[3])
                );
                Aviones.Add(a);
            }
        }

        public static void GuardarAviones()
        {
            File.WriteAllLines(FILE_AVIONES, Aviones.Select(a => a.ToString()));
        }

        public static void CargarAeropuertos()
        {
            Aeropuertos.Clear();
            if (!File.Exists(FILE_AEROPUERTOS)) return;

            foreach (var linea in File.ReadAllLines(FILE_AEROPUERTOS))
            {
                var partes = linea.Split(',');
                var ap = new Aeropuerto(
                    int.Parse(partes[0]),
                    partes[1],
                    partes[2],
                    int.Parse(partes[3])
                );
                Aeropuertos.Add(ap);
            }
        }

        public static void GuardarAeropuertos()
        {
            File.WriteAllLines(FILE_AEROPUERTOS, Aeropuertos.Select(ap => ap.ToString()));
        }
    }
}
