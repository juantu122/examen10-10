using System;

namespace GestionAerolineas
{
    [Serializable]
    public class Avion
    {
        private int id;
        private string modelo;
        private int capacidadPasajeros;
        private int anoFabricacion;
        private double velocidadMaxima;
        private double autonomiaVuelo;
        private string paisOrigen;

        public Avion(int id, string modelo, int capacidadPasajeros, int anoFabricacion)
        {
            this.id = id;
            this.modelo = modelo;
            this.capacidadPasajeros = capacidadPasajeros;
            this.anoFabricacion = anoFabricacion;
            this.velocidadMaxima = CalcularVelocidadMaxima();
            this.autonomiaVuelo = CalcularAutonomiaVuelo();
            this.paisOrigen = "Desconocido";
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Modelo
        {
            get => modelo;
            set
            {
                modelo = value;
                Recalcular();
            }
        }

        public int CapacidadPasajeros
        {
            get => capacidadPasajeros;
            set
            {
                capacidadPasajeros = value;
                Recalcular();
            }
        }

        public int AnoFabricacion
        {
            get => anoFabricacion;
            set => anoFabricacion = value;
        }

        public double VelocidadMaxima => velocidadMaxima;

        public double AutonomiaVuelo => autonomiaVuelo;

        public string PaisOrigen
        {
            get => paisOrigen;
            set => paisOrigen = value;
        }

        private double CalcularVelocidadMaxima()
        {
            return 200 + capacidadPasajeros * 5;
        }

        private double CalcularAutonomiaVuelo()
        {
            return velocidadMaxima * 5;
        }

        private void Recalcular()
        {
            velocidadMaxima = CalcularVelocidadMaxima();
            autonomiaVuelo = CalcularAutonomiaVuelo();
        }

        public override string ToString()
        {
            return $"{id},{modelo},{capacidadPasajeros},{anoFabricacion}";
        }

        public string Detalle()
        {
            var nl = Environment.NewLine;
            return "Avión {" + nl
                 + $"  Id={id}," + nl
                 + $"  Modelo={modelo}," + nl
                 + $"  Capacidad={capacidadPasajeros}," + nl
                 + $"  Año={anoFabricacion}," + nl
                 + $"  VelMax={velocidadMaxima:F2}," + nl
                 + $"  Autonomía={autonomiaVuelo:F2}," + nl
                 + $"  PaísOrigenDeRegistro=Ecuador" + nl
                 + "}";
        }

    }
}
