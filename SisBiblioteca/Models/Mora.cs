using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Mora
    {
        private int idMora;
        private PrestamoLibro prestamoLibro;
        private double cantidadMora;
        private string moraCancelada;
        private DateTime fechaPagoMora;

        public int IdMora
        {
            get
            {
                return idMora;
            }

            set
            {
                idMora = value;
            }
        }

        public PrestamoLibro PrestamoLibro
        {
            get
            {
                return prestamoLibro;
            }

            set
            {
                prestamoLibro = value;
            }
        }

        public double CantidadMora
        {
            get
            {
                return cantidadMora;
            }

            set
            {
                cantidadMora = value;
            }
        }

        public string MoraCancelada
        {
            get
            {
                return moraCancelada;
            }

            set
            {
                moraCancelada = value;
            }
        }

        public DateTime FechaPagoMora
        {
            get
            {
                return fechaPagoMora;
            }

            set
            {
                fechaPagoMora = value;
            }
        }

        public Mora(int idMora, PrestamoLibro idPrestamoLibro, double cantidadMora, string moraCancelada, DateTime fechaPagoMora)
        {
            this.IdMora = idMora;
            this.PrestamoLibro = prestamoLibro;
            this.CantidadMora = cantidadMora;
            this.MoraCancelada = moraCancelada;
            this.FechaPagoMora = fechaPagoMora;
        }
        public Mora()
        {
            prestamoLibro = new PrestamoLibro();
        }
    }
}
