using System;

namespace GestionAerolineas
{
    [Serializable]
    public class Aeropuerto
    {
        private int id;
        private string AEROPUERTO;
        private string ubicacion;
        private int numeroPistas;
        private int capacidadVuelos;
        private string fechaInauguracion;
        private string pais;

        public Aeropuerto(int id, string nombre, string ubicacion, int numeroPistas)
        {
            this.id = id;
            this.AEROPUERTO = nombre;
            this.ubicacion = ubicacion;
            this.numeroPistas = numeroPistas;
            this.capacidadVuelos = CalcularCapacidadVuelos();
            this.fechaInauguracion = DateTime.Now.ToString("dd/MM/yyyy");
            this.pais = "Ecuador";
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nombre
        {
            get => AEROPUERTO;
            set => AEROPUERTO = value;
        }

        public string Ubicacion
        {
            get => ubicacion;
            set => ubicacion = value;
        }

        public int NumeroPistas
        {
            get => numeroPistas;
            set
            {
                numeroPistas = value;
                capacidadVuelos = CalcularCapacidadVuelos();
            }
        }

        public int CapacidadVuelos => capacidadVuelos;

        public string FechaInauguracion => fechaInauguracion;

        public string Pais => pais;

        private int CalcularCapacidadVuelos()
        {
            return numeroPistas * 10;
        }

        public override string ToString()
        {
            return $"{id},{AEROPUERTO},{ubicacion},{numeroPistas}";
        }

        public string Detalle()
        {
            var nl = Environment.NewLine;
            return "Aeropuerto:" + nl
                 + $"  Id: {id}" + nl
                 + $"  Aeropuerto: {AEROPUERTO}" + nl
                 + $"  Ubicación: {ubicacion}" + nl
                 + $"  Pistas: {numeroPistas}" + nl
                 + $"  CapVuelos: {capacidadVuelos}" + nl
                 + $"  Inauguración: {fechaInauguracion}" + nl
                 + $"  PaísDeRegistro: {pais}";
        }

    }
}
